using System;

namespace _36
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = "me";

            if (userName.Length >= 3)
            {
                Console.WriteLine("Hello " + userName);
            }
            else
            {
                Console.WriteLine("Invalid user name.");
            }
        }
    }
}
