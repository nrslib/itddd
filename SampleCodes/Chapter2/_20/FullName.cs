using System;

namespace _20
{
    class FullName : IEquatable<FullName>
    {
        public FullName(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }

        public bool Equals(FullName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName 
                   && LastName == other.LastName 
                   && MiddleName == other.MiddleName; // 条件式の追加はここだけ
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullName) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, MiddleName);
        }

        public static bool operator ==(FullName left, FullName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FullName left, FullName right)
        {
            return !Equals(left, right);
        }
    }
}
