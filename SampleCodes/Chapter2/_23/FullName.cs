using System;

namespace _23
{
    class FullName : IEquatable<FullName>
    {
        private readonly FirstName firstName;
        private readonly LastName lastName;

        public FullName(FirstName firstName, LastName lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals(FullName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(firstName, other.firstName) && Equals(lastName, other.lastName);
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
            unchecked
            {
                return ((firstName != null ? firstName.GetHashCode() : 0) * 397) ^ (lastName != null ? lastName.GetHashCode() : 0);
            }
        }
    }
}
