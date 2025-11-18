using EuphoriaCommerce.Domain.IdentityEntities;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EuphoriaCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // REGISTER DB CONTEXT
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        // REGISTER IDENTITY
        // REGISTER IDENTITY
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
       
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()

            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, string>>()

            .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, string>>();
        
        
        // REGISTER UNIT OF WORK
        
        
        // REGISTER GENERIC REPOSITORY 
        
        
        // REGISTER REPOSITORIES    
        
        return services;
    }
}
