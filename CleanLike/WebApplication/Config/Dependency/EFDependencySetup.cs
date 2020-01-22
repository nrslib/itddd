using ClArc.Builder;
using EFInfrastructure.Contexts;
using EFInfrastructure.Persistence.Circles;
using EFInfrastructure.Persistence.Users;
using EFInfrastructure.QueryService.Circles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnsApplication.Circles.Interactors;
using SnsApplication.Users.Interactors;
using SnsApplicationPort.Circles.Create;
using SnsApplicationPort.Circles.Delete;
using SnsApplicationPort.Circles.Get;
using SnsApplicationPort.Circles.GetAll;
using SnsApplicationPort.Circles.GetCandidates;
using SnsApplicationPort.Circles.GetSummaries;
using SnsApplicationPort.Circles.Join;
using SnsApplicationPort.Circles.Update;
using SnsApplicationPort.Users.Delete;
using SnsApplicationPort.Users.Get;
using SnsApplicationPort.Users.GetAll;
using SnsApplicationPort.Users.Register;
using SnsApplicationPort.Users.Update;
using SnsDomain.Models.Circles;
using SnsDomain.Models.Users;
using SnsDomain.Services;

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
            SetupDomainServices(services);
            SetupUseCases(services);
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

        private void SetupDomainServices(IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<CircleService>();
        }

        private void SetupUseCases(IServiceCollection services)
        {
            var busBuilder = new SyncUseCaseBusBuilder(services);

            busBuilder.RegisterUseCase<CircleCreateInputData, CircleCreateInteractor>();
            busBuilder.RegisterUseCase<CircleDeleteInputData, CircleDeleteInteractor>();
            busBuilder.RegisterUseCase<CircleGetInputData, CircleGetInteractor>();
            busBuilder.RegisterUseCase<CircleGetAllInputData, CircleGetAllInteractor>();
            busBuilder.RegisterUseCase<CircleGetCandidatesInputData, EFCircleGetCandidatesInteractor>();
            busBuilder.RegisterUseCase<CircleGetSummariesInputData, EFMemoryCircleGetSummariesInteractor>();
            busBuilder.RegisterUseCase<CircleJoinInputData, CircleJoinInteractor>();
            busBuilder.RegisterUseCase<CircleUpdateInputData, CircleUpdateInteractor>();
            
            busBuilder.RegisterUseCase<UserDeleteInputData, UserDeleteInteractor>();
            busBuilder.RegisterUseCase<UserGetInputData, UserGetInteractor>();
            busBuilder.RegisterUseCase<UserGetAllInputData, UserGetAllInteractor>();
            busBuilder.RegisterUseCase<UserRegisterInputData, UserRegisterInteractor>();
            busBuilder.RegisterUseCase<UserUpdateInputData, UserUpdateInteractor>();

            var bus = busBuilder.Build();
            services.AddSingleton(bus);
        }
    }
}
