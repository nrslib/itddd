using System;

namespace _9
{
    public class User
    {
        // はじめてインスタンスを生成する際に利用する
        public User(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = new UserId(Guid.NewGuid().ToString());
            Name = name;
        }

        // インスタンスを再構成する際に利用する
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
        }

        public UserId Id { get; }
        public UserName Name { get; private set; }

        
        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
