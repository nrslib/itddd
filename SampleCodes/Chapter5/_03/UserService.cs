namespace _03
{
    class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool Exists(User user)
        {
            var found = userRepository.Find(user.Name);

            return found != null;
        }
    }
}
