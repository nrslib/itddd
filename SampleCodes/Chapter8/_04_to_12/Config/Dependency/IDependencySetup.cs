using Microsoft.Extensions.DependencyInjection;

namespace _04_to_12.Config.Dependency
{
    public interface IDependencySetup
    {
        void Run(IServiceCollection services);
    }
}
