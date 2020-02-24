using _19.SnsDomain.Models.Users;

namespace _19.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
