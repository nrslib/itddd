using System;

namespace _09
{
    public class User
    {
        private UserName name;

        public User(UserName name)
        {
            this.name = name;
        }

        public UserId Id { get; set; }
    }
}
