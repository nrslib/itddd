using System;

namespace _03
{
    public class User
    {
        public User(UserName name, MailAddress mail)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (mail == null) throw new ArgumentNullException(nameof(mail));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
            Mail = mail;
        }

        public User(UserId id, UserName name, MailAddress mail)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (mail == null) throw new ArgumentNullException(nameof(mail));

            Id = id;
            Name = name;
            Mail = mail;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }
        public MailAddress Mail { get; private set; }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
