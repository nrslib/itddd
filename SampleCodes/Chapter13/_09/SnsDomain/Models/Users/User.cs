using System;

namespace _09.SnsDomain.Models.Users
{
    public class User
    {
        public User(UserId id, UserName name, bool isPremium = false)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            IsPremium = isPremium;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }
        public bool IsPremium { get; private set; }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
