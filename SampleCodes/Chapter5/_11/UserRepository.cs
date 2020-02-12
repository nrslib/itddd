using System.Configuration;
using System.Data.SqlClient;

namespace _11
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void Save(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
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

        public User Find(UserName userName)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", userName.Value));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader["id"] as string;
                        var name = reader["name"] as string;

                        return new User(
                            new UserId(id),
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
    }
}
