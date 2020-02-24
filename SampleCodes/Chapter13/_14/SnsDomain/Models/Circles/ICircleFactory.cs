using _14.SnsDomain.Models.Users;

namespace _14.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
