namespace _40
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;
        private bool sendMail;

        public UserApplicationService(IUserRepository userRepository, UserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public void ChangeSendMailSetting(bool isSend)
        {
            sendMail = isSend;
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

            if (sendMail)
            {
                MailUtility.Send("user registered");
            }
        }
    }
}
