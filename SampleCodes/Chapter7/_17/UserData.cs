namespace _17
{
    public class UserData
    {
        public UserData(User source)
        {
            Id = source.Id.Value;
            Name = source.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}