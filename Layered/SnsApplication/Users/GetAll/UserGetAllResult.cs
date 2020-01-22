using System.Collections.Generic;
using SnsApplication.Users.Commons;

namespace SnsApplication.Users.GetAll
{
    public class UserGetAllResult
    {
        public UserGetAllResult(List<UserData> users)
        {
            Users = users;
        }

        public List<UserData> Users { get; }
    }
}
