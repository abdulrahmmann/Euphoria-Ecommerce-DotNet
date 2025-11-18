using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;

public class LoginUserCommandHandler(
    UserManager<ApplicationUser> userManager, 
    SignInManager<ApplicationUser> signInManager,
    IGenerateTokenService tokenService,
    IValidator<LoginUserDto> validator
    ) : ICommandHandler<LoginUserCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> HandleAsync(LoginUserCommand command, CancellationToken cancellationToken = default)
    {
        var request = command.UserDto;
        
        try
        {
            // validate input DTO.
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                
                return AuthenticationResponse.Failure("Validation failed.", validationErrors, HttpStatusCode.UnprocessableEntity);
            }
            
            // check existing user.
            var user = await userManager.FindByEmailAsync(request.Email);
            
            if (user is null)
            {
                return AuthenticationResponse.Failure("Email Does not exists.", statusCode: HttpStatusCode.NotFound);
            }
            
            if (await userManager.IsLockedOutAsync(user))
                return AuthenticationResponse.Failure("Account is locked. Try again later.");

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure:true);
            
            if (!result.Succeeded)
            {
                return AuthenticationResponse.Failure("Invalid login attempt.", statusCode: HttpStatusCode.Unauthorized);
            }

            var tokenResponse = tokenService.GenerateToken(user);

            return tokenResponse;
        }
        catch (Exception e)
        {
            return AuthenticationResponse.Failure("Unexpected server error. Please try again later."); 
        }
    }
}