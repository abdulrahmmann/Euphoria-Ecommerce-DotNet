using EuphoriaCommerce.Application.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EuphoriaCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Redis Cache
        services.AddScoped<IRedisCacheService, RedisCacheService>();
        
        
        // Register JWT Services

        
        // Register FLUENT VALIDATION
  
        
        // Register CQRS Functionality: Request + handler

        
        return services;
    }
}