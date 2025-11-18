using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.ChangePassword;

public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager)
    : ICommandHandler<ChangePasswordCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> HandleAsync(ChangePasswordCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(command.Email))
                return AuthenticationResponse.Failure("Email is required.", statusCode:HttpStatusCode.BadRequest);

            var user = await userManager.FindByEmailAsync(command.Email);
            
            if (user == null) return AuthenticationResponse.Failure("User not found.", statusCode:HttpStatusCode.NotFound);
            
            var result = await userManager.ChangePasswordAsync(
                user, 
                command.PasswordDto.CurrentPassword, 
                command.PasswordDto.NewPassword
            );

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return AuthenticationResponse.Failure($"Failed to change password: {errors}", statusCode:HttpStatusCode.BadRequest);
            }

            return AuthenticationResponse.Success("Password changed successfully.");

        }
        catch (Exception e)
        {
            return AuthenticationResponse
                .Failure("Unexpected server error. Please try again later.", statusCode:HttpStatusCode.InternalServerError); 
        }
    }
}