using _04.SnsDomain.Models.Users;

namespace _04.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
