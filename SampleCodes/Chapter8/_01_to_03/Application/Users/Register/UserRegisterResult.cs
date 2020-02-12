namespace _01_to_03.Application.Users.Register
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
