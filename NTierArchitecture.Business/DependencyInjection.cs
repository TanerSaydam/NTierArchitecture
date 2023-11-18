using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.Business.Behaviors;

namespace NTierArchitecture.Business;
public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(
        this IServiceCollection services)
    {
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfr.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
