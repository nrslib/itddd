using System.Collections.Generic;
using System.Data.SqlClient;
using SnsApplicationPort.Circles.GetSummaries;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.QueryService.Circles
{
    public class SqlCircleGetSummariesInteractor : ICircleGetSummariesInputPort
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlCircleGetSummariesInteractor(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public CircleGetSummariesOutputData Handle(CircleGetSummariesInputData inputData)
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
                var page = inputData.Page;
                var size = inputData.Size;
                sqlCommand.Parameters.Add(new SqlParameter("@skip", (page - 1) * size));
                sqlCommand.Parameters.Add(new SqlParameter("@size", size));

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var summaries = new List<CircleSummaryData>();
                    while (reader.Read())
                    {
                        var circleId = (string)reader["circleId"];
                        var ownerName = (string)reader["ownerName"];
                        var summary = new CircleSummaryData(circleId, ownerName);
                        summaries.Add(summary);
                    }

                    return new CircleGetSummariesOutputData(summaries);
                }
            }
        }
    }
}
