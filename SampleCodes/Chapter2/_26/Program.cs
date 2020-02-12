namespace _26
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = new Name("masanobu");
            var lastName = new Name("naruse");
            var name = new FullName(firstName, lastName);
        }
    }
}
