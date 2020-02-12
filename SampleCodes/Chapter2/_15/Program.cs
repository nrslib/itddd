using System;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameA = new FullName("masanobu", "naruse");
            var nameB = new FullName("john", "smith");

            var compareResult = nameA.FirstName == nameB.FirstName
                                && nameA.LastName == nameB.LastName;

            Console.WriteLine(compareResult);
        }
    }
}
