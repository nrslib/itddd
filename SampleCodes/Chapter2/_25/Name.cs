using System;
using System.Text.RegularExpressions;

namespace _25
{
    class Name
    {
        private readonly string value;

        public Name(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$")) throw new ArgumentException("許可されていない文字が使われています。", nameof(value));

            this.value = value;
        }
    }
}
