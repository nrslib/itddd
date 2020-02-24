using System;

namespace _05
{
    public class User
    {
        private UserName name;
        private Password password;

        public User(UserId id, UserName name, Password password)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (password == null) throw new ArgumentNullException(nameof(password));
            Id = id;
            this.name = name;
            this.password = password;
        }

        public UserId Id { get; }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.name = name;
        }

        public bool IsSamePassword(Password password)
        {
            return this.password.Equals(password);
        }
    }
}
