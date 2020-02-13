using System;

namespace _14
{
    public class CircleName
    {
        public CircleName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("サークル名は３文字以上です");
            if (value.Length < 20) throw new ArgumentException("サークル名は２０文字以下です");

            Value = value;
        }

        public string Value { get; }
    }
}
