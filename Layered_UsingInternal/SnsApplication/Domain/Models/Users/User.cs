using System;
using CommonLibrary.Objects;

namespace SnsApplication.Domain.Models.Users
{
    public class User
    {
        public User(UserId id, UserName name, UserType type)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            Type = type;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }
        public UserType Type { get; private set; }

        internal bool IsPremium => Type == UserType.Premium;

        internal void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        internal void Upgrade()
        {
            Type = UserType.Premium;
        }

        internal void Downgrade()
        {
            Type = UserType.Normal;
        }

        public override string ToString()
        {
            var sb = new ObjectValueStringBuilder(nameof(Id), Id)
                .Append(nameof(Name), Name);

            return sb.ToString();
        }
    }
}
