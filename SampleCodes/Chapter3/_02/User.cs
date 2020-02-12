using System;

namespace _02
{
    class User
    {
        private string name;

        public User(string name)
        {
            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("ユーザ名は３文字以上です。", nameof(name));

            this.name = name;
        }
    }
}
