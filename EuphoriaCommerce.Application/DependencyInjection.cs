using EuphoriaCommerce.Application.Caching;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.ChangePassword;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GeneratePrincipalJwtToken;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateRefreshToken;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;
using EuphoriaCommerce.Application.Features.UsersFeature.Validations;
using EuphoriaCommerce.Domain.CQRS;
using FluentValidation;
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
        services.AddScoped<IGenerateTokenService, GenerateTokenService>();
        services.AddScoped<IGenerateRefreshTokenService, GenerateRefreshTokenService>();
        services.AddScoped<IGeneratePrincipalFromJwtTokenService, GeneratePrincipalFromJwtTokenService>();
        
        // Register Fluent Validation
        // USER VALIDATOR
        services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
        
        // Register CQRS Functionality: Request + handler
        
        // Users
        services.AddTransient<ICommandHandler<RegisterUserCommand, AuthenticationResponse>, RegisterUserCommandHandler>();
        services.AddTransient<ICommandHandler<LoginUserCommand, AuthenticationResponse>, LoginUserCommandHandler>();
        services.AddTransient<ICommandHandler<ChangePasswordCommand, AuthenticationResponse>, ChangePasswordCommandHandler>();
        
        return services;
    }
}