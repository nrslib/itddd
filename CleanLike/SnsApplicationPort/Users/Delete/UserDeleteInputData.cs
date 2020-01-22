using ClArc.Sync.Core;

namespace SnsApplicationPort.Users.Delete
{
    public class UserDeleteInputData : IInputData<UserDeleteOutputData>
    {
        public UserDeleteInputData(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
