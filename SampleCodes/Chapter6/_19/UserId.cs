using System;

namespace _19
{
    public class UserId : IEquatable<UserId>
    {
        public UserId(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("valueがnullまたは空文字です");

            Value = value;
        }

        public string Value { get; }

        public bool Equals(UserId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserId) obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}
