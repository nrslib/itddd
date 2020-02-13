using _16.Domain.Models.Users;

namespace _16.Domain.Shared
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
