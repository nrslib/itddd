using System;

namespace _04
{
    class User
    {
        public User(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
        }

        public UserId Id { get; }
        public UserName Name { get; }
    }
}
