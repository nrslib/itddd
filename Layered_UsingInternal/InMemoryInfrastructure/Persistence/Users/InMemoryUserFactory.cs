using InMemoryInfrastructure.Foundation.Factory;
using SnsApplication.Domain.Models.Users;

namespace InMemoryInfrastructure.Persistence.Users
{
    public class InMemoryUserFactory : IUserFactory
    {
        public SerialNumberAssigner NumberAssigner { get; } = new SerialNumberAssigner();

        public User Create(UserName name)
        {
            var rawId = NumberAssigner.Next();

            return new User(
                new UserId(rawId.ToString()),
                name,
                UserType.Normal
            );
        }
    }
}
