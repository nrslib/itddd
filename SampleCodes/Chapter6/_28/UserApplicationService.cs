namespace _28
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
                new UserName(name), 
                new MailAddress(mailAddress)
            );
            // ドメインサービスを利用して重複を確認する
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

        public void Update(UserUpdateCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.Find(targetId); 
            
            if (user == null)
            {
                throw new UserNotFoundException(targetId);
            }

            var name = command.Name;
            if (name != null)
            {
                var newUserName = new UserName(name);
                user.ChangeName(newUserName);
                if (userService.Exists(user))
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }
            }

            var mailAddress = command.MailAddress;
            if (mailAddress != null)
            {
                var newMailAddress = new MailAddress(mailAddress);
                user.ChangeMailAddress(newMailAddress);
            }

            userRepository.Save(user);
        }

        public void Delete(UserDeleteCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.Find(targetId);

            if (user == null)
            {
                // 対象が見つからなかったため退会成功とする
                return;
            }

            userRepository.Delete(user);
        }
    }
}
