using EFInfrastructure.Persistence.DataModels;
using WebApplication.Models.Users.Commons;

namespace WebApplication.Models.Users.Get
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
