using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = "john smith";
            var tokens = fullName.Split(' '); // ["john", "smith"] という配列に
            var lastName = tokens[0];
            Console.WriteLine(lastName); // john が表示される
        }
    }
}
