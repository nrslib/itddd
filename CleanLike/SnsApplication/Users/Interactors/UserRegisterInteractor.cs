using System.Transactions;
using SnsApplicationPort.Users.Register;
using SnsDomain.Models.Users;
using SnsDomain.Services;

namespace SnsApplication.Users.Interactors
{
    public class UserRegisterInteractor : IUserRegisterInputPort
    {
        private readonly IUserFactory userFactory;
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserRegisterInteractor(IUserFactory userFactory, IUserRepository userRepository, UserService userService)
        {
            this.userFactory = userFactory;
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public UserRegisterOutputData Handle(UserRegisterInputData inputData)
        {
            using var transaction = new TransactionScope();

            var name = new UserName(inputData.Name);
            var user = userFactory.Create(name);
            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
            }

            userRepository.Save(user);

            transaction.Complete();

            return new UserRegisterOutputData(user.Id.Value);
        }
    }
}
