using System;

namespace _06
{
    class User : IEquatable<User>
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

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(id, other.id); // 比較は id 同士で行われる
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        // 言語によりGetHashCodeの実装が不要な場合もある
        public override int GetHashCode()
        {
            return (id != null ? id.GetHashCode() : 0);
        }
    }
}
