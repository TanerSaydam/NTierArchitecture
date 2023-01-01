using NTierArchitecture.Core;

namespace NTierArchitecture.WebApi.Configuration
{
    public class ServicesServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCoreService();
        }
    }
}
