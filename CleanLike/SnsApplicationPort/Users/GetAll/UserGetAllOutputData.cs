using System.Collections.Generic;
using ClArc.Sync.Core;
using SnsApplicationPort.Users.Commons;

namespace SnsApplicationPort.Users.GetAll
{
    public class UserGetAllOutputData : IOutputData
    {
        public UserGetAllOutputData(List<UserData> users)
        {
            Users = users;
        }

        public List<UserData> Users { get; }
    }
}
