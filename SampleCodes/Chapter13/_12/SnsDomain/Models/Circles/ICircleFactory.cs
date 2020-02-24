using _12.SnsDomain.Models.Users;

namespace _12.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
