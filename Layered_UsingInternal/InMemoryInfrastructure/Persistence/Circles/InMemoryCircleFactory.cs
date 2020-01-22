using System.Collections.Generic;
using InMemoryInfrastructure.Foundation.Factory;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;

namespace InMemoryInfrastructure.Persistence.Circles
{
    public class InMemoryCircleFactory : ICircleFactory
    {
        public SerialNumberAssigner NumberAssigner { get; } = new SerialNumberAssigner();

        public Circle Create(CircleName name, User owner)
        {
            var rawId = NumberAssigner.Next();

            return new Circle(
                new CircleId(rawId.ToString()),
                name,
                owner.Id,
                new List<UserId>()
            );
        }
    }
}
