using System.Linq;
using System.Transactions;
using _13.SnsApplication.Users.Commons;
using _13.SnsApplication.Users.Delete;
using _13.SnsApplication.Users.Get;
using _13.SnsApplication.Users.GetAll;
using _13.SnsApplication.Users.Register;
using _13.SnsApplication.Users.Update;
using _13.SnsDomain.Models.Users;

namespace _13.SnsApplication.Users
{
    public class UserApplicationService
    {
        private readonly IUserFactory userFactory; 
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserApplicationService(IUserFactory userFactory, IUserRepository userRepository, UserService userService)
        {
            this.userFactory = userFactory;
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

        public void Register(UserRegisterCommand command)
        {
            // トランザクションスコープを生成する
            // using句のスコープ内でコネクションが開かれると自動的にトランザクションが開始される
            using (var transaction = new TransactionScope())
            {
                var name = new UserName(command.Name);
                var user = userFactory.Create(name);

                if (userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }

                userRepository.Save(user);
                // 処理を反映する際にはコミット処理を行う
                transaction.Complete();
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
