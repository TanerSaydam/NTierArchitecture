using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Core;
using NTierArchitecture.Core.Exceptions;
using NTierArchitecture.Core.Utilities.Security;
using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Helpers;
using NTierArchitecture.WebApi.Configuration;
using NTierArchitecture.WebApi.Options;
using NTierAtchitecture.Entities.Concrete.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(builder.Configuration,
    typeof(IServiceInstaller).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandlerHelper();

app.MapControllers();

app.MigrateDatabase().Run();
