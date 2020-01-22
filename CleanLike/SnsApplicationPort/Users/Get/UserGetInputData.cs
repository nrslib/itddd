using ClArc.Sync.Core;

namespace SnsApplicationPort.Users.Get
{
    public class UserGetInputData : IInputData<UserGetOutputData>
    {
        public UserGetInputData(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
