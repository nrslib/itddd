using _02.SnsDomain.Models.Users;

namespace _02.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
