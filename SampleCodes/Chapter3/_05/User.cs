using System;

namespace _05
{
    class User
    {
        private readonly UserId id; // 識別子
        private string name;

        public User(UserId id, string name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            this.id = id;
            ChangeUserName(name);
        }

        public void ChangeUserName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("ユーザ名は３文字以上です。", nameof(name));

            this.name = name;
        }
    }
}
