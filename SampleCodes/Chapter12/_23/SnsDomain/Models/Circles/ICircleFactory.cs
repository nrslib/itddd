using _22.SnsDomain.Models.Users;

namespace _22.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
