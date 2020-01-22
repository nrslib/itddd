using ClArc.Sync.Core;

namespace SnsApplicationPort.Users.Update
{
    public class UserUpdateInputData : IInputData<UserUpdateOutputData>
    {
        public UserUpdateInputData(string id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
