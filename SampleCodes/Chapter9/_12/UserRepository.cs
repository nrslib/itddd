using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _12
{
    public class UserRepository : IUserRepository
    {
        private readonly NumberingApi numberingApi;

        public UserRepository(NumberingApi numberingApi)
        {
            this.numberingApi = numberingApi;
        }

        public void Save(User user)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
 MERGE INTO users
   USING (
     SELECT @id AS id, @name AS name
   ) AS data
   ON users.id = data.id 
   WHEN MATCHED THEN
     UPDATE SET name = data.name
   WHEN NOT MATCHED THEN
     INSERT (id, name)
     VALUES (data.id, data.name);
";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));

                command.ExecuteNonQuery();
            }
        }

        // リレーショナルデータベースを利用しているが
        public User Find(UserId id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", id.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var name = reader["name"] as string;
                        return new User(
                            id,
                            new UserName(name)
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        // 採番処理はリレーショナルデータベースを利用していない
        public UserId NextIdentity()
        {
            var response = numberingApi.Request();
            return new UserId(response.NextId);
        }
    }
}
