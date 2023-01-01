using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierAtchitecture.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.DataAccess.Context
{
    public class NTierArchitectureDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public NTierArchitectureDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
