using System;
using System.Text.RegularExpressions;

namespace _24
{
    class FullName : IEquatable<FullName>
    {
        private readonly string firstName;
        private readonly string lastName;

        public FullName(string firstName, string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (!ValidateName(firstName)) throw new ArgumentException("許可されていない文字が使われています。", nameof(firstName));
            if (!ValidateName(lastName)) throw new ArgumentException("許可されていない文字が使われています。", nameof(lastName));

            this.firstName = firstName;
            this.lastName = lastName;
        }

        private bool ValidateName(string value)
        {
            // アルファベットに限定する
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        public bool Equals(FullName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return firstName == other.firstName && lastName == other.lastName;
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
            return HashCode.Combine(firstName, lastName);
        }
    }
}
