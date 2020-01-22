using System;
using SnsApplication.Domain.Models.Users;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.Persistence.Users
{
    public class SqlUserFactory : IUserFactory
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlUserFactory(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public User Create(UserName name)
        {
            var rawId = AssignId();

            return new User(
                new UserId(rawId),
                name,
                UserType.Normal
            );
        }

        private string AssignId()
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "SELECT id FROM users ORDER BY id DESC";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var max = Convert.ToInt32(reader["id"]);
                        var id = max + 1;
                        return id.ToString();
                    }
                    else
                    {
                        return "1";
                    }
                }
            }
        }
    }
}
