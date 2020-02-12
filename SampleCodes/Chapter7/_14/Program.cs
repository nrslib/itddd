namespace _14
{
    class Program
    {
        public static void Main(string[] args)
        {
            var userRepository = new InMemoryUserRepository();
            var userApplicationService = new UserApplicationService(userRepository);
        }
    }
}
