using System;

namespace _23
{
    class LastName
    {
        private readonly string value;

        public LastName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("１文字以上である必要があります。", nameof(value));

            this.value = value;
        }
    }
}
