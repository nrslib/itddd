using System;

namespace _07
{
    public class UserName : IEquatable<UserName>
    {
        public UserName(string value) {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザ名は3文字以上です。", nameof(value));
            if (value.Length > 20) throw new ArgumentException("ユーザ名は20文字以下です。", nameof(value));

            Value = value;
        }

        public string Value { get; }

        public bool Equals(UserName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserName) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
