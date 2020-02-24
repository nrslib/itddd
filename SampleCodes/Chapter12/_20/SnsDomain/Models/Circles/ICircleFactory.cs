using _20.SnsDomain.Models.Users;

namespace _20.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
