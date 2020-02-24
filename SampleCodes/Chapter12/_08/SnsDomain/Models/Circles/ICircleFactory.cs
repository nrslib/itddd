using _08.SnsDomain.Models.Users;

namespace _08.SnsDomain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
