using System;
using System.Collections.Generic;
using System.Text;
using _16.Domain.Models.Users;
using _16.Domain.Shared;

namespace _16
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        // インメモリのリポジトリを利用している
        private InMemoryUserRepository userRepository;

        public IUserRepository UserRepository
        {
            get => userRepository ?? (userRepository = new InMemoryUserRepository());
        }

        public void Commit()
        {
            userRepository?.Commit();
        }
    }
}
