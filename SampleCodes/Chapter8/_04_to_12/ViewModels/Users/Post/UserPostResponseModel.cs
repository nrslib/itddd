namespace _04_to_12.ViewModels.Users.Post
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
