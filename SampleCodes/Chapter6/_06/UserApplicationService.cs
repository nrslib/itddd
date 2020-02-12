namespace _06
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

        public void Register(string name)
        {
            var user = new User(
                new UserName(name)
            );
            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
            }

            userRepository.Save(user);
        }

        public User Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = userRepository.Find(targetId);

            return user;
        }
    }
}
