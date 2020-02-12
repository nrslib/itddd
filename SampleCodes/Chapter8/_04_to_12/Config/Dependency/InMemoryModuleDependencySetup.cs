using _04_to_12.Application.Users;
using _04_to_12.InMemoryInfrastructure;
using _04_to_12.Models.Users;
using Microsoft.Extensions.DependencyInjection;

namespace _04_to_12.Config.Dependency
{
    public class InMemoryModuleDependencySetup : IDependencySetup
    {
        public void Run(IServiceCollection services)
        {
            SetupRepositories(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        }

        private void SetupApplicationServices(IServiceCollection
            services)
        {
            services.AddTransient<UserApplicationService>();
        }

        private void SetupDomainServices(IServiceCollection services)
        {
            services.AddTransient<UserService>();
        }
    }
}
