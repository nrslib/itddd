using System.Configuration;
using System.Data.SqlClient;

namespace _7
{
    public class UserRepository : IUserRepository
    {
        public User Find(UserId userId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", userId.Value));
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
