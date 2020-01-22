using ClArc.Sync.Core;

namespace SnsApplicationPort.Users.Register
{
    public class UserRegisterOutputData : IOutputData
    {
        public UserRegisterOutputData(string createdUserId)
        {
            CreatedUserId = createdUserId;
        }

        public string CreatedUserId { get; }
    }
}
