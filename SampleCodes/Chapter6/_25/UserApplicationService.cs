namespace _25
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;

        public UserApplicationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(string name, string rawMailAddress)
        {
            // メールアドレスによる重複確認を行うように変更された
            var mailAddress = new MailAddress(rawMailAddress);
            var duplicatedUser = userRepository.Find(mailAddress);
            if (duplicatedUser != null)
            {
                throw new CanNotRegisterUserException(mailAddress);
            }

            var userName = new UserName(name);
            var user = new User(
                userName,
                mailAddress
            );

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
                // 重複確認を行うコード
                var newUserName = new UserName(name);
                var duplicatedUser = userRepository.Find(newUserName);
                if (duplicatedUser != null)
                {
                    throw new CanNotRegisterUserException(user, "ユーザは既に存在しています。");
                }
                user.ChangeName(newUserName);
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
