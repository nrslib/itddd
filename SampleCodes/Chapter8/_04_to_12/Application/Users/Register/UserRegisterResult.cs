namespace _04_to_12.Application.Users.Register
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
