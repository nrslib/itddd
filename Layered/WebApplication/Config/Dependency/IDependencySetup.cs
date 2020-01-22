using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Config.Dependency
{
    public interface IDependencySetup
    {
        void Run(IServiceCollection services);
    }
}
