using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SnsApplication.Circles;
using SnsApplication.Circles.GetCandidates;
using SnsApplication.Circles.GetSummaries;
using SnsApplication.Users.Commons;
using SnsDomain.Models.Circles;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.QueryService
{
    public class SqlCircleQueryService : ICircleQueryService
    {
        private readonly DatabaseConnectionProvider provider;
        private readonly ICircleRepository circleRepository;

        public SqlCircleQueryService(DatabaseConnectionProvider provider, ICircleRepository circleRepository)
        {
            this.provider = provider;
            this.circleRepository = circleRepository;
        }


        public CircleGetSummariesResult GetSummaries(CircleGetSummariesCommand command)
        {
            var connection = provider.Connection;

            using (var sqlCommand = connection.CreateCommand())
            {
                sqlCommand.CommandText = @"
 SELECT
   circles.id as circleId,
   users.name as ownerName
 FROM circles
 LEFT OUTER JOIN users
   ON circles.ownerId = users.id
 ORDER BY circles.id
 OFFSET @skip ROWS
 FETCH NEXT @size ROWS ONLY
";
                var page = command.Page;
                var size = command.Size;
                sqlCommand.Parameters.Add(new SqlParameter("@skip", (page - 1) * size));
                sqlCommand.Parameters.Add(new SqlParameter("@size", size));

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var summaries = new List<CircleSummaryData>();
                    while (reader.Read())
                    {
                        var circleId = (string) reader["circleId"];
                        var ownerName = (string) reader["ownerName"];
                        var summary = new CircleSummaryData(circleId, ownerName);
                        summaries.Add(summary);
                    }

                    return new CircleGetSummariesResult(summaries);
                }
            }
        }

        public CircleGetCandidatesResult GetCandidates(CircleGetCandidatesCommand command)
        {
            var circleId = new CircleId(command.CircleId);
            var circle = circleRepository.Find(circleId);
            if (circle == null)
            {
                throw new CircleNotFoundException(circleId);
            }

            using (var sqlCommand = provider.Connection.CreateCommand())
            {
                var parameterNames = circle.Members.Select((_, i) => "@member" + i).ToList();

                var selectQuery = new StringBuilder(@" SELECT * FROM users");

                var appendWhere = false;
                if (circle.ExistsOwner())
                {
                    selectQuery.Append(" WHERE id <> @ownerId");
                    appendWhere = true;
                }

                if (parameterNames.Any())
                {
                    var inParameters = string.Join(",", parameterNames);
                    var inPhrase =  new StringBuilder();
                    if (appendWhere)
                    {
                        inPhrase.Append(" AND");
                    }
                    inPhrase.Append($" id NOT IN ({inParameters})");
                    
                    if (!appendWhere)
                    {
                        selectQuery.Append(" WHERE");
                        appendWhere = true;
                    }

                    selectQuery.Append(inPhrase);
                }
                selectQuery.Append(@"
 ORDER BY id
   OFFSET @skip ROWS
   FETCH NEXT @size ROWS ONLY
");

                sqlCommand.CommandText = selectQuery.ToString();

                if (circle.ExistsOwner())
                {
                    sqlCommand.Parameters.Add(new SqlParameter("@ownerId", circle.Owner.Value));
                }

                foreach (var tpl in circle.Members.Zip(parameterNames, (memberId, parameter) => new { memberId, parameter}))
                {
                    sqlCommand.Parameters.Add(new SqlParameter(tpl.parameter, tpl.memberId.Value));
                }

                var page = command.Page;
                var size = command.Size;
                sqlCommand.Parameters.Add(new SqlParameter("@skip", (page - 1) * size));
                sqlCommand.Parameters.Add(new SqlParameter("@size", size));

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var members = new List<UserData>();
                    while (reader.Read())
                    {
                        var id = (string) reader["id"];
                        var name = (string) reader["name"];
                        var data = new UserData(id, name);

                        members.Add(data);
                    }

                    return new CircleGetCandidatesResult(members);
                }
            }
        }
    }
}
