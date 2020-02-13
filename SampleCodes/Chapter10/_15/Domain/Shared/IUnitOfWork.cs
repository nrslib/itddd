using _15.Domain.Models.Users;

namespace _15.Domain.Shared
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
