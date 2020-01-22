using SnsDomain.Models.Users;

namespace SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
