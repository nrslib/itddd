using System;

namespace _07
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
            // ユーザ名により重複確認を行うという知識は失われている
            return userRepository.Exists(user);
        }
    }
}
