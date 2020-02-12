using System;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameA = new FullName("masanobu", "naruse");
            var nameB = new FullName("masanobu", "naruse");

            // 別個のインスタンス同士の比較
            Console.WriteLine(nameA.Equals(nameB)); // インスタンスを構成する属性が等価なのでtrue
        }
    }
}
