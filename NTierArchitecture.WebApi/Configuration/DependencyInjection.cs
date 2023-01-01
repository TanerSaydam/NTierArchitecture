using Microsoft.Identity.Client;
using System.Linq;
using System.Reflection;

namespace NTierArchitecture.WebApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration,params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies.SelectMany(a => a.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (var serviceInstaller in serviceInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;

            static bool IsAssignableToType<T>(TypeInfo typeInfo)=> 
                typeof(T).IsAssignableFrom(typeInfo) 
                && !typeInfo.IsAbstract
                && !typeInfo.IsInterface;            
        }
    }
}
