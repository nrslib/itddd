using System;

namespace _04
{
    class User
    {
        private readonly UserId id;

        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.Name = name;
        }

        public UserName Name { get; }

        // 追加した重複確認のふるまい
        public bool Exists(User user)
        {
            // 重複を確認するコード
            return false;
        }
    }
}
