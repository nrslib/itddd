using SnsApplication.Users.Commons;

namespace SnsApplication.Users.Get
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
