using SnsApplication.Domain.Models.Users;

namespace SnsApplication.Domain.Models.Circles
{
    public interface ICircleFactory
    {
        Circle Create(CircleName name, User owner);
    }
}
