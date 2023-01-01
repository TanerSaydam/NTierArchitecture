using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Context;
using NTierAtchitecture.Entities.Concrete.Identity;

namespace NTierArchitecture.WebApi.Configuration
{
    public class DbContextServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NTierArchitectureDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<NTierArchitectureDbContext>();
        }
    }
}
