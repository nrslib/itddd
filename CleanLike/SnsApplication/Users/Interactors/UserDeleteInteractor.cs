using System;
using System.Transactions;
using SnsApplicationPort.Users.Delete;
using SnsDomain.Models.Users;

namespace SnsApplication.Users.Interactors
{
    public class UserDeleteInteractor : IUserDeleteInputPort
    {
        private readonly IUserRepository userRepository;

        public UserDeleteInteractor(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserDeleteOutputData Handle(UserDeleteInputData inputData)
        {
            using var transaction = new TransactionScope();

            var id = new UserId(inputData.Id);
            var user = userRepository.Find(id);
            if (user == null)
            {
                return new UserDeleteOutputData();
            }

            userRepository.Delete(user);

            transaction.Complete();

            return new UserDeleteOutputData();
        }
    }
}
