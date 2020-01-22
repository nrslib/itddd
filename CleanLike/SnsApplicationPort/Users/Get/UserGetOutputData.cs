using ClArc.Sync.Core;
using SnsApplicationPort.Users.Commons;

namespace SnsApplicationPort.Users.Get
{
    public class UserGetOutputData : IOutputData
    {
        public UserGetOutputData(UserData user)
        {
            User = user;
        }

        public UserData User { get; }
    }
}
