namespace _13
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceLocator.Register<IUserRepository, InMemoryUserRepository>();
            var userApplicationService = new UserApplicationService();
        }
    }
}
