namespace _01_to_03.Models.Users
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Exists(User user)
        {
            var duplicatedUser = userRepository.Find(user.Name);

            return duplicatedUser != null;
        }
    }
}
