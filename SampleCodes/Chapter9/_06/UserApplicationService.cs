using System;

namespace _06
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

        public void Register(UserRegisterCommand command)
        {
            var userName = new UserName(command.Name);
            // ファクトリによってインスタンスを生成する
            var user = userFactory.Create(userName);

            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user);
            }

            userRepository.Save(user);
        }
    }
}
