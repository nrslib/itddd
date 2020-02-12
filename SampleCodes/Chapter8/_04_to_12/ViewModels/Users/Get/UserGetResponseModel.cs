using _04_to_12.ViewModels.Users.Commons;

namespace _04_to_12.ViewModels.Users.Get
{
    public class UserGetResponseModel
    {
        public UserGetResponseModel(UserResponseModel user)
        {
            User = user;
        }

        public UserResponseModel User { get; set; }
    }
}
