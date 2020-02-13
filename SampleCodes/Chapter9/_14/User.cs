using System;

namespace _14
{
    public class User
    {
        private readonly UserId id;
        private UserName name;

        // コンストラクタがあることがわかるのみ
        public User(UserId id, UserName name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }

        public UserId Id => id;
        public UserName Name => name;

        public void ChangeName(UserName name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.name = name;
        }

        // ファクトリとして機能するメソッド
        public Circle CreateCircle(CircleName circleName)
        {
            return new Circle(
                id,
                circleName
            );
        }
    }
}
