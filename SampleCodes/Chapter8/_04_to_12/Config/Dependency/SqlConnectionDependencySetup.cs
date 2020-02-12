using _04_to_12.Application.Users;
using _04_to_12.Models.Users;
using _04_to_12.SqlInfrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _04_to_12.Config.Dependency
{
    public class SqlConnectionDependencySetup : IDependencySetup
    {
        private readonly IConfiguration configuration;

        public SqlConnectionDependencySetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run(IServiceCollection services)
        {
            SetupRepositories(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, SqlUserRepository>();
        }

        private void SetupApplicationServices(IServiceCollection services)
        {
            services.AddTransient<UserApplicationService>();
        }

        private void SetupDomainServices(IServiceCollection services)
        {
            services.AddTransient<UserService>();
        }
    }
}