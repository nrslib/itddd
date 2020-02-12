namespace _32
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

        public void Register(UserRegisterCommand command)
        {
            var user = new User(
                new UserName(command.Name)
            );

            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
            }

            userRepository.Save(user);
        }

        public void Delete(UserDeleteCommand command)
        {
            var userId = new UserId(command.Id);
            var user = userRepository.Find(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            userRepository.Delete(user);
        }
    }
}
