using System;

namespace _37
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = "me";

            if (userName.Length >= 3)
            {
                // 正常な値なので処理を継続する
            }
            else
            {
                throw new Exception("異常な値です");
            }
        }
    }
}
