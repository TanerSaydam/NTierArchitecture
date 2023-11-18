using Microsoft.Extensions.DependencyInjection;

namespace NTierArchitecture.Business;
public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(
        this IServiceCollection services)
    {
        return services;
    }
}
