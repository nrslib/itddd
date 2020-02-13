using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using _13.Domain.Models.Users;

namespace _13.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;

        public UserRepository(SqlConnection connection, SqlTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public User Find(UserId id)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", id.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var user = Read(reader);

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public User Find(UserName name)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users WHERE name = @name";
                command.Parameters.Add(new SqlParameter("@name", name.Value));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var user = Read(reader);

                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<User> FindAll()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM users";

                using (var reader = command.ExecuteReader())
                {
                    var results = new List<User>();
                    while (reader.Read())
                    {
                        var user = Read(reader);
                        results.Add(user);
                    }

                    return results;
                }
            }
        }

        public void Save(User user)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
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

        public void Delete(User user)
        {
            using (var command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "DELETE FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.ExecuteNonQuery();
            }
        }

        public User Read(SqlDataReader reader)
        {
            var id = (string)reader["id"];
            var name = (string)reader["name"];

            return new User(
                new UserId(id),
                new UserName(name)
            );
        }
    }
}
