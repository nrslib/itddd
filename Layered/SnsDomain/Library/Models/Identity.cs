using System;
using System.Collections.Generic;

namespace SnsDomain.Library.Models
{
    public class Identity : Identity<string>
    {
        public Identity(string value) : base(value)
        {
        }
    }

    public class Identity<T> : IEquatable<Identity<T>>
    {
        public Identity(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public T Value { get; }

        public bool Equals(Identity<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identity<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }
    }
}