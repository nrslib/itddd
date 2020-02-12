using System;

namespace _09
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
