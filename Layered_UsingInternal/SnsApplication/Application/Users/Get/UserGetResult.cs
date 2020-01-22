using SnsApplication.Application.Users.Commons;

namespace SnsApplication.Application.Users.Get
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
