using ClArc.Sync.Core;

namespace SnsApplicationPort.Users.Register
{
    public class UserRegisterInputData : IInputData<UserRegisterOutputData>
    {
        public UserRegisterInputData(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
