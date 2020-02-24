using System;

namespace Authenticate.Model.Users
{
    public class User
    {
        private Password password;

        public User(UserName id, Password password)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (password == null) throw new ArgumentNullException(nameof(password));

            Id = id;
            this.password = password;
        }

        public UserName Id { get; }

        public bool IsSamePassword(Password password)
        {
            return this.password.Equals(password);
        }
    }
}
