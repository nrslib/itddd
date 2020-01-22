using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SnsApplication.Domain.Models.Users;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.Persistence.Users
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlUserRepository(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public User Find(UserId id)
        {
            using (var command = provider.Connection.CreateCommand())
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
            using (var command = provider.Connection.CreateCommand())
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

        public List<User> Find(IEnumerable<UserId> aIds)
        {
            var ids = aIds.ToList();
            if (!ids.Any())
            {
                throw new ArgumentException("empty.", nameof(aIds));
            }

            using (var command = provider.Connection.CreateCommand())
            {
                var parameterNames = ids.Select((_, i) => "@id" + i).ToList();

                var inParameters = string.Join(",", parameterNames);

                command.CommandText = $"SELECT * FROM users WHERE id IN ({inParameters})";
                

                foreach (var tpl in ids.Zip(parameterNames, (id, parameter) => new {id, parameter}))
                {
                    command.Parameters.Add(new SqlParameter(tpl.parameter, tpl.id));
                }

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

        public List<User> FindAll()
        {
            using (var command = provider.Connection.CreateCommand())
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
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = @"
 MERGE INTO users
   USING (
     SELECT @id AS id, @name AS name, @type AS type
   ) AS data
   ON users.id = data.id 
   WHEN MATCHED THEN
     UPDATE SET name = data.name, type = data.type
   WHEN NOT MATCHED THEN
     INSERT (id, name, type)
     VALUES (data.id, data.name, data.type);
";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.Parameters.Add(new SqlParameter("@name", user.Name.Value));
                command.Parameters.Add(new SqlParameter("@type", (int)user.Type));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(User user)
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM users WHERE id = @id";
                command.Parameters.Add(new SqlParameter("@id", user.Id.Value));
                command.ExecuteNonQuery();
            }
        }

        public User Read(SqlDataReader reader)
        {
            var id = (string) reader["id"];
            var name = (string) reader["name"];
            var type = (int) reader["type"];

            return new User(
                new UserId(id),
                new UserName(name),
                (UserType) type
            );
        }
    }
}