using System;
using System.Collections.Generic;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;
using SQLInfrastructure.Provider;

namespace SQLInfrastructure.Persistence.Circles
{
    public class SqlCircleFactory : ICircleFactory
    {
        private readonly DatabaseConnectionProvider provider;

        public SqlCircleFactory(DatabaseConnectionProvider provider)
        {
            this.provider = provider;
        }

        public Circle Create(CircleName name, User owner)
        {
            var rawId = AssignId();

            return new Circle(
                new CircleId(rawId),
                name,
                owner.Id,
                new List<UserId>()
            );
        }

        private string AssignId()
        {
            using (var command = provider.Connection.CreateCommand())
            {
                command.CommandText = "SELECT id FROM circles ORDER BY id DESC";
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
