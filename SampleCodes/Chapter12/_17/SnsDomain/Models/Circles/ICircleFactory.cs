using _17.SnsDomain.Models.Users;

namespace _17.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
