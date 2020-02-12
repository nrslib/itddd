using System;

namespace _14
{
    public class User
    {
        // はじめてインスタンスを生成する際に利用する
        public User(UserName name, MailAddress mailAddress)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (mailAddress == null) throw new ArgumentNullException(nameof(mailAddress));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
            MailAddress = mailAddress;
        }

        // インスタンスを再構成する際に利用する
        public User(UserId id, UserName name, MailAddress mailAddress)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (mailAddress == null) throw new ArgumentNullException(nameof(mailAddress));

            Id = id;
            Name = name;
            MailAddress = mailAddress;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }
        public MailAddress MailAddress { get; }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
