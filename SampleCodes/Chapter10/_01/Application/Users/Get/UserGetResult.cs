namespace _01.Application.Users.Get
{
    public class UserGetResult
    {
        public UserGetResult(UserData user)
        {
            Domain.Models.Users.User = user;
        }

        public UserData User { get; }
    }
}
