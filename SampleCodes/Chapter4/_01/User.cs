using System;

namespace _01
{
    class User
    {
        private readonly UserId id;
        private UserName name;

        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));
            this.id = id;
            this.name = name;
        }

        // 追加した重複確認のふるまい
        public bool Exists(User user)
        {
            // 重複を確認するコード
            return false;
        }
    }
}
