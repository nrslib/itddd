using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;

namespace SQLInfrastructure.Persistence.Circles
{
    public class SqlCircleBuilder
    {
        private string id;
        private string name;
        private string ownerId;
        private List<string> members = new List<string>();

        public SqlCircleBuilder(SqlDataReader reader)
        {
            ReadCircle(reader);
        }

        public SqlCircleBuilder()
        {
        }

        public string CircleId => id;

        public SqlCircleBuilder ReadCircle(SqlDataReader reader)
        {
            id = (string)reader["id"];
            name = (string)reader["name"];
            var ownerIdOrDbNull = reader["ownerId"];
            ownerId = DBNull.Value.Equals(ownerIdOrDbNull) ? null : (string) ownerIdOrDbNull;

            return this;
        }

        public SqlCircleBuilder ReadAppendMember(SqlDataReader reader)
        {
            var id = (string)reader["userId"];
            members.Add(id);

            return this;
        }

        public void Clear()
        {
            id = null;
            name = null;
            ownerId = null;
            members = new List<string>();
        }

        public Circle Build()
        {
            return new Circle(
                new CircleId(id),
                new CircleName(name),
                ownerId != null ? new UserId(ownerId) : null,
                members.Select(s => new UserId(s)).ToList()
            );
        }
    }
}
