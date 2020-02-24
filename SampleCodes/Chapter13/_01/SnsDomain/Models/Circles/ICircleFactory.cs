using _01.SnsDomain.Models.Users;

namespace _01.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
