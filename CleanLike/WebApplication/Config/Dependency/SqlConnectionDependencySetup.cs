using ClArc.Builder;
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
using SQLInfrastructure.Persistence.Circles;
using SQLInfrastructure.Persistence.Users;
using SQLInfrastructure.Provider;
using SQLInfrastructure.QueryService.Circles;

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
            SetupDomainServices(services);
            SetupUseCases(services);
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
            busBuilder.RegisterUseCase<CircleGetCandidatesInputData, SqlCircleGetCandidatesInteractor>();
            busBuilder.RegisterUseCase<CircleGetSummariesInputData, SqlCircleGetSummariesInteractor>();
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