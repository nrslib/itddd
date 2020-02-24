using _11.SnsApplication.Users.Commons;

namespace _11.SnsApplication.Users.Get
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
