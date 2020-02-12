namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new MyProgram();
            var user = new User("test-user");
            var request = new UserChangeNameRequest {Name = null};
            program.Main(user, request);
        }
    }
}
