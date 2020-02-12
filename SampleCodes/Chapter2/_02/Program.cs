using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = "naruse masanobu";
            var tokens = fullName.Split(' '); // ["naruse", "masanobu"] という配列に
            var lastName = tokens[0];
            Console.WriteLine(lastName); // naruse が表示される
        }
    }
}
