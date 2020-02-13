using System.Collections.Generic;
using _06.Application.Users.Commons;

namespace _06.Application.Users.GetAll
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
