using System.Linq;
using _15.Application.Users.Commons;
using _15.Application.Users.Delete;
using _15.Application.Users.Get;
using _15.Application.Users.GetAll;
using _15.Application.Users.Register;
using _15.Application.Users.Update;
using _15.Domain.Models.Users;
using _15.Domain.Shared;

namespace _15.Application.Users
{
    public class UserApplicationService
    {
        // ユニットオブワークを保持する
        private readonly IUnitOfWork uow;
        private readonly IUserFactory userFactory; 
        private readonly UserService userService;

        public UserApplicationService(IUnitOfWork uow, IUserFactory userFactory, UserService userService)
        {
            this.uow = uow;
            this.userFactory = userFactory;
            this.userService = userService;
        }

        public UserGetResult Get(UserGetCommand command)
        {
            var id = new UserId(command.Id);
            var user = uow.UserRepository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException(id, "ユーザが見つかりませんでした。");
            }

            var data = new UserData(user);

            return new UserGetResult(data);
        }

        public UserGetAllResult GetAll()
        {
            var users = uow.UserRepository.FindAll();
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

            uow.UserRepository.Save(user);
            uow.Commit();
        }

        public void Update(UserUpdateCommand command)
        {
            var id = new UserId(command.Id);
            var user = uow.UserRepository.Find(id);
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

            uow.UserRepository.Save(user);
            uow.Commit();
        }

        public void Delete(UserDeleteCommand command)
        {
            var id = new UserId(command.Id);
            var user = uow.UserRepository.Find(id);
            if (user == null)
            {
                return;
            }

            uow.UserRepository.Delete(user);
            uow.Commit();
        }
    }
}
