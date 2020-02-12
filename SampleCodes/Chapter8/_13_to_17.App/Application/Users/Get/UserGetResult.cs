using _13_to_17.App.Application.Users.Commons;

namespace _13_to_17.App.Application.Users.Get
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
