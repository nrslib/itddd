namespace _22
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;
        
        public UserApplicationService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Register(string name, string mailAddress)
        {
            // 重複確認を行うコード
            var userName = new UserName(name);
            var duplicatedUser = userRepository.Find(userName);
            if (duplicatedUser != null)
            {
                throw new CanNotRegisterUserException(userName, "ユーザは既に存在しています。");
            }

            var user = new User(
                userName
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
