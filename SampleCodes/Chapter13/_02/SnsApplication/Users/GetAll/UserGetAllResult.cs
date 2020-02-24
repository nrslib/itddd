using System.Collections.Generic;
using _02.SnsApplication.Users.Commons;

namespace _02.SnsApplication.Users.GetAll
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
