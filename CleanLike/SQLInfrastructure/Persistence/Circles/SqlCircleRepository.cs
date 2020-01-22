using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SnsDomain.Models.Circles;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.Persistence.Circles
{
    public class SqlCircleRepository : ICircleRepository
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlCircleRepository(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public Circle Find(CircleId id)
        {
            var builder = new SqlCircleBuilder();
            LoadMembers(builder, id.Value, provider.Connection);

            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
 SELECT *
 FROM circles
 LEFT OUTER JOIN userCircles
   ON circles.id = userCircles.circleId
 WHERE id = @id
";
                command.Parameters.Add(new SqlParameter("@id", id.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        builder.ReadCircle(reader);
                        var circle = builder.Build();

                        return circle;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Circle Find(CircleName name)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM circles WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", name.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    var builder = new SqlCircleBuilder(reader);
                    LoadMembers(builder, builder.CircleId, provider.Connection);
                    var circle = builder.Build();

                    return circle;
                }
            }
        }

        public List<Circle> FindAll()
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
 SELECT *
 FROM circles
 LEFT OUTER JOIN userCircles
   ON circles.id = userCircles.circleId
";

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return new List<Circle>();
                    }

                    var builder = new SqlCircleBuilder(reader);

                    var circles = new List<Circle>();
                    while (reader.Read())
                    {
                        var circleId = (string) reader["id"];
                        if (circleId != builder.CircleId)
                        {
                            var circle = builder.Build();
                            circles.Add(circle);

                            builder.Clear();
                            builder.ReadCircle(reader);
                        }

                        builder.ReadAppendMember(reader);
                    }

                    var lastCircle = builder.Build();
                    circles.Add(lastCircle);

                    return circles;
                }
            }
        }

        public void Save(Circle circle)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
 MERGE INTO circles
   USING (
     SELECT @id AS id, @name AS name, @ownerId AS ownerId
   ) AS data
   ON circles.id = data.id 
   WHEN MATCHED THEN
     UPDATE SET name = data.name, ownerId = data.ownerId
   WHEN NOT MATCHED THEN
     INSERT (id, name, ownerId)
     VALUES (data.id, data.name, data.ownerId);
";
                command.Parameters.Add(new SqlParameter("@id", circle.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", circle.Name.Value));
                command.Parameters.Add(new SqlParameter("@ownerId", (object)circle.Owner?.Value ?? DBNull.Value));

                command.ExecuteNonQuery();
            }

            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
 MERGE INTO userCircles
   USING (
     SELECT @userId AS userId, @circleId AS circleId
   ) AS data
   ON userCircles.userId = data.userId AND userCircles.circleId = data.circleId
   WHEN NOT MATCHED THEN
     INSERT (userId, circleId)
     VALUES (data.userId, data.circleId);
";
                command.Parameters.Add(new SqlParameter("@circleId", circle.Id.Value));
                command.Parameters.Add(new SqlParameter("@userId", null));

                foreach (var memberId in circle.Members)
                {
                    command.Parameters["@userId"].Value = memberId.Value;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Circle circle)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM circles WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", circle.Id.Value));

                command.ExecuteNonQuery();
            }
        }

        private void LoadMembers(SqlCircleBuilder builder, string circleId, SqlConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM userCircles WHERE circleId = @id";
                command.Parameters.Add(new SqlParameter("@id", circleId));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        builder.ReadAppendMember(reader);
                    }
                }
            }
        }
    }
}
