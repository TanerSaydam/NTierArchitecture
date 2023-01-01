using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NTierArchitecture.DataAccess.Context;
using NTierAtchitecture.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Helpers
{
    public static class MigrationHelper
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<NTierArchitectureDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            try
            {
                db.Database.Migrate();

                if(!userManager.Users.Any()) 
                    userManager.CreateAsync(new AppUser { Id=Guid.NewGuid().ToString(), UserName="tanersaydam", Email="tanersaydam@gmail.com" }, "Password12*").Wait();
            }
            catch (Exception)
            {
                throw new Exception("We're having problem with migrate database!");
            }

            return host;
        }
    }
}
