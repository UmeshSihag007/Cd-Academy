using Data.Comman;
using Domain.Models.Comman;

namespace WebApi.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

        return services;
    }
}
