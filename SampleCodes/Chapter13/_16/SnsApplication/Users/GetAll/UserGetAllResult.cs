using System.Collections.Generic;
using _16.SnsApplication.Users.Commons;

namespace _16.SnsApplication.Users.GetAll
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
