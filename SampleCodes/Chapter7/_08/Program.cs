namespace _8
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceLocator.Register<IUserRepository, InMemoryUserRepository>();
            var applicationService = new UserApplicationService();
            var result = applicationService.Get("test-user-id");
        }
    }
}
