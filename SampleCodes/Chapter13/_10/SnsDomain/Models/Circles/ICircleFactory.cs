using _10.SnsDomain.Models.Users;

namespace _10.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
