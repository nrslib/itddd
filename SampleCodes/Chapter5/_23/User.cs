using System;

namespace _23
{
    class User
    {
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
        }

        public User(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }

        public void ChangeUserName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
