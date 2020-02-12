using System;

namespace _47
{
    class User
    {
        public User(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public UserName Name { get; set; }
    }
}
