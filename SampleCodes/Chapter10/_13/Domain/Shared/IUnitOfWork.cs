using _13.Domain.Models.Users;

namespace _13.Domain.Shared
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
