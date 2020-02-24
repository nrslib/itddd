using _13.SnsDomain.Models.Users;

namespace _13.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
