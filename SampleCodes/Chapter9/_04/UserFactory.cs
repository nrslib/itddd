using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _04
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserName name)
        {
            string seqId;

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT seq = (NEXT VALUE FOR UserSeq)";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var rawSeqId = reader["seq"];
                        seqId = rawSeqId.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            var id = new UserId(seqId);
            return new User(id, name);
        }
    }
}
