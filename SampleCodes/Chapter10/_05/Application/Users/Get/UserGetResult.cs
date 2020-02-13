using _05.Application.Users.Commons;

namespace _05.Application.Users.Get
{
    public class UserGetResult
    {
        public UserGetResult(UserData user)
        {
            User = user;
        }

        public UserData User { get; }
    }
}
