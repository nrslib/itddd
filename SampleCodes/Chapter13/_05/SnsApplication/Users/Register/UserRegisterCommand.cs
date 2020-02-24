namespace _05.SnsApplication.Users.Register
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
