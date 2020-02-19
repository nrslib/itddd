using _06.SnsDomain.Models.Users;

namespace _06.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
