namespace SnsApplication.Users.Register
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
