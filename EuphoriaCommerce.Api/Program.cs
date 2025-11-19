using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using Euphoria_ecommerce.Middlewares;
using Euphoria_ecommerce.SeedData;
using EuphoriaCommerce.Application;
using EuphoriaCommerce.Application.Extensions;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Domain;
using EuphoriaCommerce.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));

    // var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    // options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Serilog
builder.Host.SerilogConfiguration();

// REGISTER AUTHENTICATION & AUTHORIZATIONS
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// ADDING AUTHENTICATION
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = jwtSettings!.Audience,
        ValidIssuer = jwtSettings!.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

        RoleClaimType = ClaimTypes.Role,
        
        ValidateLifetime = true,
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;

    // options.SignIn.RequireConfirmedAccount = true;
    // options.SignIn.RequireConfirmedEmail = true;
});

// REGISTER LAYERS DEPENDENCIES
builder.Services
    .AddDomainDependencies(builder.Configuration)
    .AddInfrastructureDependencies(builder.Configuration)
    .AddApplicationDependencies(builder.Configuration);


// REGISTER API VERSIONING
builder.Services.AddApiVersioning(config =>
{
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// REDIS
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");

    options.InstanceName = "HappyWarehouses_";
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//
//     var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//     await DbSeedData.SeedAdminsAsync(services);
//     await DbSeedData.SeedRolesAsync(roleManager);
// }


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();