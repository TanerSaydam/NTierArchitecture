using NTierArchitecture.Core.Exceptions;

namespace NTierArchitecture.WebApi.Configuration
{
    public class DependencyInjectionServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ExceptionHandler>();
        }
    }
}
