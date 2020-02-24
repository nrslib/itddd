using System.Collections.Generic;
using System.Data.SqlClient;
using _17.SnsDomain.Library.Specifications;
using _17.SnsDomain.Models.Circles;
using _17.SnsDomain.Models.Users;

namespace _17.SqlInfrastructure.Persistence
{
    public class CircleRepository : ICircleRepository
    {
        private readonly SqlConnection connection;

        public CircleRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Save(Circle circle)
        {
            throw new System.NotImplementedException();
        }

        public Circle Find(CircleId id)
        {
            throw new System.NotImplementedException();
        }

        public Circle Find(CircleName name)
        {
            throw new System.NotImplementedException();
        }

        public List<Circle> Find(ISpecification<Circle> specification)
        {
            using (var command = connection.CreateCommand())
            {
                // 全件取得するクエリを発行
                command.CommandText = "SELECT * FROM circles";
                using (var reader = command.ExecuteReader())
                {
                    var circles = new List<Circle>();
                    while (reader.Read())
                    {
                        // インスタンスを生成して条件に合うか確認している（合わなければ捨てられる）
                        var circle = CreateInstance(reader);
                        if (specification.IsSatisfiedBy(circle))
                        {
                            circles.Add(circle);
                        }
                    }
                    return circles;
                }
            }
        }

        private Circle CreateInstance(SqlDataReader reader)
        {
            return new Circle(
                new CircleId((string) reader["id"]),
                new CircleName((string) reader["name"]),
                new UserId((string) reader["owner"]),
                new List<UserId>()
            );
        }
    }
}
