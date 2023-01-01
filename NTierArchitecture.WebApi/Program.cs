using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Core;
using NTierArchitecture.Core.Exceptions;
using NTierArchitecture.Core.Utilities.Security;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Helpers;
using NTierArchitecture.WebApi.Options;
using NTierAtchitecture.Entities.Concrete.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region DbContext
builder.Services.AddDbContext<NTierArchitectureDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<NTierArchitectureDbContext>();
#endregion

#region ServiceRegistration
builder.Services.AddCoreService();
#endregion

#region Jwt
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddAuthentication().AddJwtBearer();
#endregion

builder.Services.AddTransient<ExceptionHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandlerHelper();

app.MapControllers();

app.MigrateDatabase().Run();
