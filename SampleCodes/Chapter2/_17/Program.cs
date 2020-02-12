using System;

namespace _17
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameA = new FullName("masanobu", "naruse");
            var nameB = new FullName("john", "smith");

            var compareResult = nameA.Equals(nameB);
            Console.WriteLine(compareResult);

            // 演算子のオーバーライド機能を活用することも選択肢に入る
            var compareResult2 = nameA == nameB;
            Console.WriteLine(compareResult2);
        }
    }
}
