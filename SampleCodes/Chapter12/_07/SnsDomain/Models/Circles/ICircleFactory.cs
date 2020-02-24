using _07.SnsDomain.Models.Users;

namespace _07.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
