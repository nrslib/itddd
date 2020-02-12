namespace _13
{
    public class UserData
    {
        public UserData(User source)
        {
            Id = source.Id.Value;
            Name = source.Name.Value;
            MailAddress = source.MailAddress.Value; // 属性への代入処理
        }

        public string Id { get; }
        public string Name { get; }
        public string MailAddress { get; } // 追加された属性
    }
}
