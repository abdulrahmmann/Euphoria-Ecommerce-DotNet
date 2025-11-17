using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EuphoriaCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // REGISTER DB CONTEXT
       
        
        // REGISTER IDENTITY
        
        
        // REGISTER UNIT OF WORK
        
        
        // REGISTER GENERIC REPOSITORY 
        
        
        // REGISTER REPOSITORIES    
        
        return services;
    }
}
