using System;

namespace _43
{
    class UserId
    {
        private readonly string value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }
    }
}
