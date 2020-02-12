using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = new FullName("masanobu", "naruse");
            Console.WriteLine(fullName.LastName); // naruse が表示される
        }
    }
}
