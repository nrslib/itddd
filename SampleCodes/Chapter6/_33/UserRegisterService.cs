namespace _33
{
    public class UserRegisterService
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        public UserRegisterService(IUserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public void Handle(UserRegisterCommand command)
        {
            var userName = new UserName(command.Name);

            var user = new User(
                userName
            );

            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
            }

            userRepository.Save(user);
        }
    }
}
