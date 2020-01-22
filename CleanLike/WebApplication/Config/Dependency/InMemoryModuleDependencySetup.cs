using ClArc.Builder;
using InMemoryInfrastructure.Persistence.Circles;
using InMemoryInfrastructure.Persistence.Users;
using InMemoryInfrastructure.QueryService.Circles;
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
    public class InMemoryModuleDependencySetup : IDependencySetup
    {
        public void Run(IServiceCollection services)
        {
            SetupFactories(services);
            SetupRepositories(services);
            SetupDomainServices(services);
            SetupUseCases(services);
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
            busBuilder.RegisterUseCase<CircleGetCandidatesInputData, InMemoryCircleGetCandidatesInteractor>();
            busBuilder.RegisterUseCase<CircleGetSummariesInputData, InMemoryCircleGetSummariesInteractor>();
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
