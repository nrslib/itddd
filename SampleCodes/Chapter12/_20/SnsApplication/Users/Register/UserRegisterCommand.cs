namespace _20.SnsApplication.Users.Register
{
    public class UserRegisterCommand
    {
        public UserRegisterCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
