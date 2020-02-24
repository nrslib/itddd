using System;

namespace Core.Model.Users
{
    public class User
    {
        private UserName name;
        
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            this.name = name;
        }

        public UserId Id { get; }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.name = name;
        }
    }
}
