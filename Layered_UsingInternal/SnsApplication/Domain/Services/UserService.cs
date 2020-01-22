using SnsApplication.Domain.Models.Users;

namespace SnsApplication.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        internal bool Exists(User user)
        {
            var duplicatedUser = userRepository.Find(user.Name);

            return duplicatedUser != null;
        }
    }
}
