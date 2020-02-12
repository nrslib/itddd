namespace _13_to_17.App.Application.Users.Register
{
    public class UserRegisterResult
    {
        public UserRegisterResult(string createdUserId)
        {
            CreatedUserId = createdUserId;
        }

        public string CreatedUserId { get; }
    }
}
