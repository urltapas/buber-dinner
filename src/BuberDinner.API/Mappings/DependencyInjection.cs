using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDinner.API.Mappings;

public static class DependencyInjection 
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
