namespace _12
{
    public class UserData
    {
        public UserData(User source) // ドメインオブジェクトを受け取っている
        {
            Id = source.Id.Value;
            Name = source.Name.Value;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
