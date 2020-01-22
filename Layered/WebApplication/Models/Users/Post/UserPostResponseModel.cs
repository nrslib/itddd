namespace WebApplication.Models.Users.Post
{
    public class UserPostResponseModel
    {
        public UserPostResponseModel(string createdUserId)
        {
            CreatedUserId = createdUserId;
        }

        public string CreatedUserId { get; }
    }
}
