using System;

namespace _42
{
    class UserName
    {
        private readonly string value;

        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }
    }
}
