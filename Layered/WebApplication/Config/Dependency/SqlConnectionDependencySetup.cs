using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnsApplication.Circles;
using SnsApplication.Users;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;
using SnsDomain.Services;
using SQLInfrastructure.Persistence.Circles;
using SQLInfrastructure.Persistence.Users;
using SQLInfrastructure.Provider;
using SQLInfrastructure.QueryService;

namespace WebApplication.Config.Dependency
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
            SetupFactories(services);
            SetupRepositories(services);
            SetupQueryServices(services);
            SetupApplicationServices(services);
            SetupDomainServices(services);
        }

        private void SetupFactories(IServiceCollection services)
        {
            services.AddTransient<IUserFactory, SqlUserFactory>();
            services.AddTransient<ICircleFactory, SqlCircleFactory>();
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddScoped(_ => new DatabaseConnectionProvider(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserRepository, SqlUserRepository>();
            services.AddTransient<ICircleRepository, SqlCircleRepository>();
        }

        private void SetupQueryServices(IServiceCollection services)
        {
            services.AddTransient<ICircleQueryService, SqlCircleQueryService>();
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