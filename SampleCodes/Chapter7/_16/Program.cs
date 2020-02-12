namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new InMemoryUserRepository();
            // 第2引数にIFooRepositoryの実体が渡されていないためコンパイルエラーとなる
            // var userApplicationService = new UserApplicationService(userRepository);
        }
    }
}
