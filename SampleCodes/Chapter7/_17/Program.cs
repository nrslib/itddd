using Microsoft.Extensions.DependencyInjection;

namespace _17
{
    class Program
    {
        static void Main(string[] args)
        {
            // IoC Container
            var serviceCollection = new ServiceCollection();
            // 依存解決の設定を登録する
            serviceCollection.AddTransient<IUserRepository, InMemoryUserRepository>();
            serviceCollection.AddTransient<UserApplicationService>();

            // インスタンスはIoC Container経由で取得する
            var provider = serviceCollection.BuildServiceProvider();
            var userApplicationService = provider.GetService<UserApplicationService>();
        }
    }
}
