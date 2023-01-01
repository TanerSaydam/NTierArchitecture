using Microsoft.AspNetCore.Authentication.JwtBearer;
using NTierArchitecture.Core.Utilities.Security;
using NTierArchitecture.WebApi.Options;

namespace NTierArchitecture.WebApi.Configuration
{
    public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddAuthentication().AddJwtBearer();
        }
    }
}
