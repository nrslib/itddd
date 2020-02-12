using System;

namespace _12
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var program = new Program(userRepository);
            program.CreateUser("naruse");
        }
    }
}
