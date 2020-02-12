using System;
using Microsoft.Extensions.Configuration;

namespace _04_to_12.Config.Dependency
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

                default:
                    throw new NotSupportedException(setupName + " is not registered.");
            }
        }
    }
}
