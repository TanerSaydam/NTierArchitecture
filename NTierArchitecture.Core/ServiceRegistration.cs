using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NTierArchitecture.Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCoreService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, JwtTokenHandler>();
            return services;
        }
    }
}
