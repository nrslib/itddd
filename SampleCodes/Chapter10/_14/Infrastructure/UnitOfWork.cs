using System.Data.SqlClient;
using _14.Domain.Models.Users;
using _14.Domain.Shared;

namespace _14.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;
        private UserRepository userRepository;

        public UnitOfWork(SqlConnection connection, SqlTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public IUserRepository UserRepository
        {
            get => userRepository ?? (userRepository = new UserRepository(connection, transaction));
        }

        public void Commit()
        {
            transaction.Commit();
        }
    }
}