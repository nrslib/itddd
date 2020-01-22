using InMemoryInfrastructure.Persistence.Circles;
using InMemoryInfrastructure.Persistence.Users;
using InMemoryInfrastructure.QueryService;
using Microsoft.Extensions.DependencyInjection;
using SnsApplication.Application.Circles;
using SnsApplication.Application.Users;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;
using SnsApplication.Domain.Services;

namespace WebApplication.Config.Dependency
{
    public class InMemoryModuleDependencySetup : IDependencySetup
    {
        public void Run(IServiceCollection services)
        {
            SetupFactories(services);
            SetupRepositories(services);
            SetupQueryServices(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupFactories(IServiceCollection services)
        {
            services.AddSingleton<IUserFactory, InMemoryUserFactory>();
            services.AddSingleton<ICircleFactory, InMemoryCircleFactory>();
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            services.AddSingleton<ICircleRepository, InMemoryCircleRepository>();
        }

        private void SetupQueryServices(IServiceCollection services)
        {
            services.AddTransient<ICircleQueryService, InMemoryCircleQueryService>();
        }

        private void SetupApplicationServices(IServiceCollection services)
        {
            services.AddTransient<UserApplicationService>();
            services.AddTransient<CircleApplicationService>();
        }

        private void SetupDomainServices(IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<CircleService>();
        }
    }
}
