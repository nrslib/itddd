namespace _10.SnsApplication.Users.Update
{
    public class UserUpdateCommand
    {
        public UserUpdateCommand(string id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
