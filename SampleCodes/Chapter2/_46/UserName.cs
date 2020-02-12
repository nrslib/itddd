using System;

namespace _46
{
    class UserName
    {
        private readonly string value;

        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザ名は3文字以上です。", nameof(value));

            this.value = value;
        }
    }
}
