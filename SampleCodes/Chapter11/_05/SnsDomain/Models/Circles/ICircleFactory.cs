using _05.SnsDomain.Models.Users;

namespace _05.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
