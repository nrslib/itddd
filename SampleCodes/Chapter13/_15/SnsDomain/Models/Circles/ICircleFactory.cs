using _15.SnsDomain.Models.Users;

namespace _15.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
