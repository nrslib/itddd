namespace _9
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceLocator.Register<IUserRepository, UserRepository>();
            var applicationService = new UserApplicationService();
            var result = applicationService.Get("test-user-id");
        }
    }
}
