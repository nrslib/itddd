using System.Collections.Generic;
using _04_to_12.ViewModels.Users.Commons;

namespace _04_to_12.ViewModels.Users.Index
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
