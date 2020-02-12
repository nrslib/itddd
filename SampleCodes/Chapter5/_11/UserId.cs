using System;

namespace _11
{
    public class UserId
    {
        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }

        public string Value { get; }
    }
}
