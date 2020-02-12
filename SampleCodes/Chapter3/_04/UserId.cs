using System;

namespace _04
{
    class UserId
    {
        private string value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }
    }
}
