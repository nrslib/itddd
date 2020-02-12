using System.Linq;
using System.Transactions;
using _04_to_12.Application.Users.Commons;
using _04_to_12.Application.Users.Delete;
using _04_to_12.Application.Users.Get;
using _04_to_12.Application.Users.GetAll;
using _04_to_12.Application.Users.Register;
using _04_to_12.Application.Users.Update;
using _04_to_12.Models.Users;

namespace _04_to_12.Application.Users
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserApplicationService(IUserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public UserGetResult Get(UserGetCommand command)
        {
            var id = new UserId(command.Id);
            var user = userRepository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException(id, "ユーザが見つかりませんでした。");
            }

            var data = new UserData(user);

            return new UserGetResult(data);
        }

        public UserGetAllResult GetAll()
        {
            var users = userRepository.FindAll();
            var userModels = users.Select(x => new UserData(x)).ToList();
            return new UserGetAllResult(userModels);
        }

        public UserRegisterResult Register(UserRegisterCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var name = new UserName(command.Name);
                var user = new User(name);
                if (userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }

                userRepository.Save(user);

                transaction.Complete();

                return new UserRegisterResult(user.Id.Value);
            }
        }

        public void Update(UserUpdateCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = new UserId(command.Id);
                var user = userRepository.Find(id);
                if (user == null)
                {
                    throw new UserNotFoundException(id);
                }

                if (command.Name != null)
                {
                    var name = new UserName(command.Name);
                    user.ChangeName(name);

                    if (userService.Exists(user))
                    {
                        throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                    }
                }

                userRepository.Save(user);

                transaction.Complete();
            }
        }

        public void Delete(UserDeleteCommand command)
        {
            using (var transaction = new TransactionScope())
            {
                var id = new UserId(command.Id);
                var user = userRepository.Find(id);
                if (user == null)
                {
                    return;
                }

                userRepository.Delete(user);

                transaction.Complete();
            }
        }
    }
}
