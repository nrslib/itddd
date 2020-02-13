using System;

namespace _01
{
    public class User
    {
        private readonly UserId id;
        private UserName name;

        // ユーザを新規作成するときのコンストラクタ
        public User(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            // GUIDを利用して識別子を生成している
            id = new UserId(Guid.NewGuid().ToString());
            this.name = name;
        }

        // ユーザを再構築するときのコンストラクタ
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }
    }
}
