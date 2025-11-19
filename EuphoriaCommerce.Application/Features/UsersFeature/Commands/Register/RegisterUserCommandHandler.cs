using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Serilog;
using StackExchange.Redis;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;

public class RegisterUserCommandHandler(
    UserManager<ApplicationUser> userManager, 
    RoleManager<IdentityRole> roleManager,
    IGenerateTokenService tokenService,
    IValidator<RegisterUserDto> validator,
    ILogger logger
    ) : ICommandHandler<RegisterUserCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        var request = command.UserDto;
        
        try
        {
            // 1️⃣ Validate DTO
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return AuthenticationResponse.Failure("Validation failed.", validationErrors, HttpStatusCode.UnprocessableEntity);
            }

            // 2️⃣ Check if user exists
            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return AuthenticationResponse.Failure("Email is already registered.", statusCode: HttpStatusCode.Conflict);

            if (await userManager.FindByNameAsync(request.Username) is not null)
                return AuthenticationResponse.Failure("Username is already taken.", statusCode: HttpStatusCode.Conflict);

            // 3️⃣ Create new user
            var newUser = ApplicationUser.Create(request.Email, request.Username);
            var identityResult = await userManager.CreateAsync(newUser, request.Password);

            if (!identityResult.Succeeded)
            {
                var createErrors = identityResult.Errors.Select(e => e.Description).ToList();
                return AuthenticationResponse.Failure("User registration failed.", createErrors, HttpStatusCode.BadRequest);
            }

            logger.Information("User {Username} created successfully.", newUser.UserName);

            // 4️⃣ Ensure role exists
            if (!await roleManager.RoleExistsAsync(Roles.User))
            {
                logger.Information("Role {Role} does not exist. Creating it.", Roles.User);
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }

            // 5️⃣ Assign role
            var roleResult = await userManager.AddToRoleAsync(newUser, Roles.User);
            if (!roleResult.Succeeded)
            {
                logger.Warning("Failed to assign role {Role} to user {Username}", Roles.User, newUser.UserName);
            }

            newUser.SetRole(Roles.User);

            // 6️⃣ Generate token
            var tokenResponse = tokenService.GenerateToken(newUser);
            newUser.SetRefreshToken(tokenResponse.RefreshToken);
            newUser.SetRefreshTokenExpiration(tokenResponse.RefreshTokenExpiration);

            await userManager.UpdateAsync(newUser);

            return tokenResponse;
        }
        catch (Exception e)
        {
            logger.Error(e, "Error registering user {Username}", request.Username);
            return AuthenticationResponse.Failure($"Unexpected server error. Please try again later: {e.Message}");
        }
    }
}