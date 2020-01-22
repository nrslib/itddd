using System.Transactions;
using SnsApplicationPort.Users.Update;
using SnsDomain.Models.Users;
using SnsDomain.Services;

namespace SnsApplication.Users.Interactors
{
    public class UserUpdateInteractor : IUserUpdateInputPort
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserUpdateInteractor(IUserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public UserUpdateOutputData Handle(UserUpdateInputData inputData)
        {
            using var transaction = new TransactionScope();

            var id = new UserId(inputData.Id);
            var user = userRepository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            if (inputData.Name != null)
            {
                var name = new UserName(inputData.Name);
                user.ChangeName(name);

                if (userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }
            }

            userRepository.Save(user);

            transaction.Complete();

            return new UserUpdateOutputData();
        }
    }
}
