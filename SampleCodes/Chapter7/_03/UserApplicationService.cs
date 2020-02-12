namespace _3
{
    public class UserApplicationService
    {
        private readonly IUserRepository userRepository;

        public UserApplicationService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
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
