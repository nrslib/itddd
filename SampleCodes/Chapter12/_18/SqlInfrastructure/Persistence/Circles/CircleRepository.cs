using System;
using System.Data.SqlClient;
using _18.SnsDomain.Models.Circles;

namespace _18.SqlInfrastructure.Persistence.Circles
{
    public class CircleRepository : ICircleRepository
    {
        private SqlConnection connection;

        public void Save(Circle circle)
        {
            // ユーザ集約に対する更新処理を行う
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE users SET username = @username WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", null));
                command.Parameters.Add(new SqlParameter("@username", null));

                foreach (var user in circle.Members)
                {
                    command.Parameters["@id"].Value = user.Id.Value;
                    command.Parameters["@username"].Value = user.Name.Value;
                    command.ExecuteNonQuery();
                }
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
 MERGE INTO circles
   USING (
     SELECT @id AS id, @name AS name, @ownerId AS ownerId
   ) AS data
   ON circles.id = data.id
   WHEN MATCHED THEN
   UPDATE SET name = data.name, ownerId = data.ownerId
   WHEN NOT MATCHED THENINSERT (id, name, ownerId)
   VALUES (data.id, data.name, data.ownerId);
";
                command.Parameters.Add(new SqlParameter("@id", circle.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", circle.Name.Value));
                command.Parameters.Add(new SqlParameter("@ownerId", (object)circle.Owner?.Id.Value ?? DBNull.Value));
                command.ExecuteNonQuery();
            }

            using (var command = connection.CreateCommand())
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
                foreach (var member in circle.Members)
                {
                    command.Parameters["@userId"].Value = member.Id.Value;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Circle Find(CircleId id)
        {
            throw new NotImplementedException();
        }

        public Circle Find(CircleName name)
        {
            throw new NotImplementedException();
        }
    }
}
