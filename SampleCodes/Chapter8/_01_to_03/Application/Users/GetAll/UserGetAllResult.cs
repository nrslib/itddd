using System.Collections.Generic;
using _01_to_03.Application.Users.Commons;

namespace _01_to_03.Application.Users.GetAll
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
