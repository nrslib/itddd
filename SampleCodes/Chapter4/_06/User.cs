namespace _06
{
    class User
    {
        private readonly UserId id;

        public User(UserId id, UserName name)
        {
            this.id = id;
            Name = name;
        }

        public UserName Name { get; set; }
    }
}
