using System;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Config.Dependency
{
    class DependencySetupFactory
    {
        public IDependencySetup CreateSetup(IConfiguration configuration)
        {
            var setupName = configuration["Dependency:SetupName"];
            switch (setupName)
            {
                case nameof(InMemoryModuleDependencySetup):
                    return new InMemoryModuleDependencySetup();

                case nameof(SqlConnectionDependencySetup):
                    return new SqlConnectionDependencySetup(configuration);

                case nameof(EFDependencySetup):
                    return new EFDependencySetup(configuration);

                default:
                    throw new NotSupportedException(setupName + " is not registered.");
            }
        }
    }
}
