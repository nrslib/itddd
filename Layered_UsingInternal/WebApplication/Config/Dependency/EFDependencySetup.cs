using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.Circles;
using EFInfrastructure.Persistence.Users;
using EFInfrastructure.QueryService.EFQueryService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnsApplication.Application.Circles;
using SnsApplication.Application.Users;
using SnsApplication.Domain.Models.Circles;
using SnsApplication.Domain.Models.Users;
using SnsApplication.Domain.Services;

namespace WebApplication.Config.Dependency
{
    public class EFDependencySetup : IDependencySetup
    {
        private readonly IConfiguration configuration;

        public EFDependencySetup(IConfiguration configuration)
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
            services.AddTransient<IUserFactory, EFUserFactory>();
            services.AddTransient<ICircleFactory, EFCircleFactory>();
        }

        private void SetupRepositories(IServiceCollection services)
        {
            services.AddDbContext<ItdddDbContext>(options =>
            {
                var isInMemory = configuration.GetValue<bool>("Dependency:Extra:EF:InMemory");
                if (isInMemory)
                {
                    options.UseInMemoryDatabase(databaseName: "ItdddContext");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
            });

            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<ICircleRepository, EFCircleRepository>();
        }

        private void SetupQueryServices(IServiceCollection services)
        {
            services.AddTransient<ICircleQueryService, EFCircleQueryService>();
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
