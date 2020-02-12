using System.Collections.Generic;
using _13_to_17.App.Application.Users.Commons;

namespace _13_to_17.App.Application.Users.GetAll
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
