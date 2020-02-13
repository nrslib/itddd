using _14.Domain.Models.Users;

namespace _14.Domain.Shared
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
