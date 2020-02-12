using System;
using _01_to_03.Application.Users;
using _01_to_03.Application.Users.Register;
using _01_to_03.InMemoryInfrastructure.Users;
using _01_to_03.Models.Users;
using Microsoft.Extensions.DependencyInjection;

namespace _01_to_03
{
    class Program
    {
        private static ServiceProvider serviceProvider;

        public static void Main(string[] args)
        {
            Startup();
            while (true)
            {
                Console.WriteLine("Input user name");
                Console.Write(">");
                var input = Console.ReadLine();
                var userApplicationService = serviceProvider.GetService<UserApplicationService>();
                var command = new UserRegisterCommand(input);
                userApplicationService.Register(command);

                Console.WriteLine("-------------------------");
                Console.WriteLine("user created:");
                Console.WriteLine("-------------------------");
                Console.WriteLine("user name:");
                Console.WriteLine("- " + input);
                Console.WriteLine("-------------------------");
                Console.WriteLine("continue? (y/n)");
                Console.Write(">");
                var yesOrNo = Console.ReadLine();
                if (yesOrNo == "n")
                {
                    break;
                }
            }
        }

        private static void Startup()
        {
            // IoC Container
            var serviceCollection = new ServiceCollection();
            // 依存関係の登録を行う（以下コメントにて補足）
            // IUserRepositoryが要求されたらInMemoryUserRepositoryを生成して引き渡す（生成したインスタンスはその後使いまわされる）
            serviceCollection.AddSingleton<IUserRepository, InMemoryUserRepository>();
            // UserServiceが要求されたら都度UserServiceを生成して引き渡す
            serviceCollection.AddTransient<UserService>();
            // UserApplicationServiceが要求されたら都度UserApplicationServiceを生成して引き渡す
            serviceCollection.AddTransient<UserApplicationService>();
            // 依存解決を行うプロバイダの生成
            // プログラムはserviceProviderに依存の解決を依頼する
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
