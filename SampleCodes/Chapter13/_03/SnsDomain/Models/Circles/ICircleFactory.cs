using _03.SnsDomain.Models.Users;

namespace _03.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
