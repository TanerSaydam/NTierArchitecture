using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTierArchitecture.Business;
using NTierArchitecture.DataAccess;
using NTierArchitecture.Entities.Options;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

var serviceProvider = builder.Services.BuildServiceProvider();

var jwtConfiguration = serviceProvider.GetRequiredService<IOptions<Jwt>>().Value;

builder.Services.AddAuthentication().AddJwtBearer(cfr =>
{
    cfr.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtConfiguration.Issuer,
        ValidAudience = jwtConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey))
    };
});
builder.Services.AddAuthorization();

builder.Services.AddBusiness();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
