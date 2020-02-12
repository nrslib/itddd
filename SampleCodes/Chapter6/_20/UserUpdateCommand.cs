namespace _20
{
    public class UserUpdateCommand
    {
        public UserUpdateCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
        /// <summary> データが設定されると変更される </summary>
        public string Name { get; set; }
    }
}
