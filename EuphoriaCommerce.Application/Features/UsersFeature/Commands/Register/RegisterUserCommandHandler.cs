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

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;

public class RegisterUserCommandHandler(
    UserManager<ApplicationUser> userManager, 
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
            // validate request DTO.
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return AuthenticationResponse.Failure("Validation failed.", validationErrors, HttpStatusCode.UnprocessableEntity);
            }
            
            // check existing user.
            var existingByEmail = await userManager.FindByEmailAsync(request.Email);
            if (existingByEmail is not null)
                return AuthenticationResponse.Failure("Email is already registered.", statusCode: HttpStatusCode.Conflict);

            var existingByUserName = await userManager.FindByNameAsync(request.Username);
            if (existingByUserName is not null)
                return AuthenticationResponse.Failure("Username is already taken.", statusCode: HttpStatusCode.Conflict);

          
            // create new user
            var newUser = ApplicationUser.Create(request.Email, request.Username);
            
            var identityResult = await userManager.CreateAsync(newUser, request.Password);
            
            if (!identityResult.Succeeded)
            {
                var createErrors = identityResult.Errors.Select(e => e.Description).ToList();
                return AuthenticationResponse.Failure("User registration failed.", createErrors, HttpStatusCode.BadRequest);
            }
            
            // Assign role
            var roleResult = await userManager.AddToRoleAsync(newUser, Roles.User);
            
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(newUser);
                var roleErrors = roleResult.Errors.Select(e => e.Description).ToList();
                return AuthenticationResponse.Failure("User registration failed.",roleErrors, HttpStatusCode.BadRequest);
            }
            
            // Generate token
            var tokenResponse = tokenService.GenerateToken(newUser);
            newUser.SetRefreshToken(tokenResponse.RefreshToken);
            newUser.SetRefreshTokenExpiration(tokenResponse.RefreshTokenExpiration);
            
            await userManager.UpdateAsync(newUser);
            
            return tokenResponse; 
        }
        catch (Exception e)
        {
            logger.Error("{e}", e.Message);
            return AuthenticationResponse.Failure($"Unexpected server error. Please try again later : {e.Message}."); 
        }
    }
}