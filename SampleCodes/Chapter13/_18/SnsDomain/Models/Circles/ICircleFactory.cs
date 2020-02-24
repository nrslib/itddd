using _18.SnsDomain.Models.Users;

namespace _18.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
