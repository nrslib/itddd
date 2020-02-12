namespace _16
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

        public void Register(string name, string mailAddress)
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

        public UserData Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = userRepository.Find(targetId);

            if (user == null)
            {
                return null;
            }

            var userData = new UserData(user);
            return userData;
        }

        // メールアドレスを引数で受け取る
        public void Update(string userId, string name = null, string mailAddress = null)
        {
            var targetId = new UserId(userId);
            var user = userRepository.Find(targetId);

            if (user == null)
            {
                throw new UserNotFoundException(targetId);
            }

            // メールアドレスだけを更新するため、ユーザ名が指定されないことを考慮
            if (name != null)
            {
                var newUserName = new UserName(name);
                user.ChangeName(newUserName);
                if (userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }
            }

            // メールアドレスを変更できるように
            if (mailAddress != null)
            {
                var newMailAddress = new MailAddress(mailAddress);
                user.ChangeMailAddress(newMailAddress);
            }

            userRepository.Save(user);
        }
    }
}
