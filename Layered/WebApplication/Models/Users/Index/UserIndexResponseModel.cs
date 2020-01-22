using System.Collections.Generic;
using WebApplication.Models.Users.Commons;

namespace WebApplication.Models.Users.Index
{
    public class UserIndexResponseModel
    {
        public UserIndexResponseModel(List<UserResponseModel> users)
        {
            Users = users;
        }

        public List<UserResponseModel> Users { get; }
    }
}
