using _09.SnsDomain.Models.Users;

namespace _09.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
