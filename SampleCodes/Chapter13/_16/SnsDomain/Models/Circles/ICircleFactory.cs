using _16.SnsDomain.Models.Users;

namespace _16.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
