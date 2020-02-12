using System;

namespace _21
{
    class FirstName
    {
        private readonly string value;

        public FirstName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("１文字以上である必要があります。", nameof(value));

            this.value = value;
        }
    }
}
