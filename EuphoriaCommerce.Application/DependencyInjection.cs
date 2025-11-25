using CloudinaryDotNet;
using EuphoriaCommerce.Application.Caching;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.CreateProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.DeleteProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.RestoreProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.UpdateProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Application.Features.ProductsFeature.Queries.GetProducts;
using EuphoriaCommerce.Application.Features.ProductsFeature.Validations;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.ChangePassword;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.CreateUser;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.GenerateNewAccessToken;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;
using EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.Helpers;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUserRole;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsers;
using EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsersByRole;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GeneratePrincipalJwtToken;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateRefreshToken;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;
using EuphoriaCommerce.Application.Features.UsersFeature.Validations;
using EuphoriaCommerce.Domain.CQRS;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
        
        // Register Cloudinary Settings
        services.AddScoped<CloudinaryService>();

        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        
        services.AddSingleton(sp =>
        {
            var config = sp.GetRequiredService<IOptions<CloudinarySettings>>().Value;
            var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
            return new Cloudinary(account);
        });

        
        
        // Register CQRS Functionality: Request + handler
        // Users
        services.AddTransient<ICommandHandler<GenerateNewAccessTokenCommand, AuthenticationResponse>, GenerateNewAccessTokenCommandHandler>();
        services.AddTransient<ICommandHandler<RegisterUserCommand, AuthenticationResponse>, RegisterUserCommandHandler>();
        services.AddTransient<ICommandHandler<LoginUserCommand, AuthenticationResponse>, LoginUserCommandHandler>();
        services.AddTransient<ICommandHandler<ChangePasswordCommand, AuthenticationResponse>, ChangePasswordCommandHandler>();
        services.AddTransient<ICommandHandler<CreateUserWithProfileCommand, AuthenticationResponse>, CreateUserWithProfileCommandHandler>();
        
        services.AddTransient<IQueryHandler<GetUsersByRoleQuery, UserResponse<List<UserDto2>>>, GetUsersByRoleQueryHandler>();
        services.AddTransient<IQueryHandler<GetUsersQuery, UserResponse<List<UserDto2>>>, GetUsersQueryHandler>();
        services.AddTransient<IQueryHandler<GetUserRolesByEmailQuery, string>, GetUserRolesByEmailQueryHandler>();
        
        // Products
        services.AddTransient<ICommandHandler<CreateProductCommand, BaseResponse<string>>, CreateProductCommandHandler>();
        services.AddTransient<ICommandHandler<UpdateProductCommand, BaseResponse<string>>, UpdateProductCommandHandler>();
        services.AddTransient<ICommandHandler<DeleteProductCommand, BaseResponse<string>>, DeleteProductCommandHandler>();
        services.AddTransient<ICommandHandler<RestoreProductCommand, BaseResponse<string>>, RestoreProductCommandHandler>();
        
        services.AddTransient<IQueryHandler<GetProductsQuery, BaseResponse<List<ProductDto>>>, GetProductsQueryHandler>();
        
        return services;
    }
}