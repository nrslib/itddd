namespace _12
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;

        public UserApplicationService()
        {
            // ServiceLocator経由でインスタンスを取得する
            this.userRepository = ServiceLocator.Resolve<IUserRepository>();
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
    }
}
