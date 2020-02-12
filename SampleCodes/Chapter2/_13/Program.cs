using System;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0 == 0); // true
            Console.WriteLine(0 == 1); // false
            Console.WriteLine('a' == 'a'); // true
            Console.WriteLine('a' == 'b'); // false
            Console.WriteLine("hello" == "hello"); // true
            Console.WriteLine("hello" == "こんにちは"); // false
        }
    }
}
