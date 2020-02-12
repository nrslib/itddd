using System.Collections.Generic;
using _04_to_12.Application.Users.Commons;

namespace _04_to_12.Application.Users.GetAll
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
