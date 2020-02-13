using System.Linq;
using System.Transactions;
using _12.Application.Users.Commons;
using _12.Application.Users.Delete;
using _12.Application.Users.Get;
using _12.Application.Users.GetAll;
using _12.Application.Users.Register;
using _12.Application.Users.Update;
using _12.Domain.Models.Users;
using _12.Domain.Shared;

namespace _12.Application.Users
{
    public class UserApplicationService
    {
        // ユニットオブワークを保持する
        private readonly UnitOfWork uow;
        private readonly IUserFactory userFactory; 
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserApplicationService(UnitOfWork uow, IUserFactory userFactory, IUserRepository userRepository, UserService userService)
        {
            this.uow = uow;
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
            var name = new UserName(command.Name);
            var user = userFactory.Create(name);

            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
            }

            userRepository.Save(user);
            uow.Commit();
        }

        public void Update(UserUpdateCommand command)
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
            uow.Commit();
        }

        public void Delete(UserDeleteCommand command)
        {
            var id = new UserId(command.Id);
            var user = userRepository.Find(id);
            if (user == null)
            {
                return;
            }

            userRepository.Delete(user);
            uow.Commit();
        }
    }
}
