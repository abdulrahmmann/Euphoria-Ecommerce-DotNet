using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.UpdateUserProfile;

public class UpdateUserProfileCommandHandler(UserManager<ApplicationUser> userManager, ILogger logger)
    : ICommandHandler<UpdateUserProfileCommand, string>
{
    public async Task<string> HandleAsync(UpdateUserProfileCommand command, CancellationToken cancellationToken = default)
    {
        var request = command.UserProfileDto;
        
        try
        {
            if (string.IsNullOrWhiteSpace(command.Email))
            {
                logger.Error("Email is required");
                return "Email is required";
            }
            
            var user = await userManager.FindByEmailAsync(command.Email);

            if (user is null)
            {
                logger.Error("User not found");
                return "User not found";
            }

            var newProfile = new UserProfile(
                request.FirstName ?? user.UserProfile?.FirstName ?? "",
                request.SecondName ?? user.UserProfile?.SecondName,
                request.LastName ?? user.UserProfile?.LastName ?? "",
                request.ProfileImageUrl ?? user.UserProfile?.ProfileImageUrl,
                request.Bio ?? user.UserProfile?.Bio ?? "",
                user.UserProfile?.Gender ?? "Male",
                request.Country ?? user.UserProfile?.Country ?? "",
                request.City ?? user.UserProfile?.City ?? "",
                request.Street ?? user.UserProfile?.Street ?? "",
                request.ZipCode ?? user.UserProfile?.ZipCode ?? "",
                user.Id
            );

            user.UpdateUserProfile(newProfile);
            
            await userManager.UpdateAsync(user);
            
            return "Success";
        }
        catch (Exception e)
        {
            logger.Error(e, "Unexpected error while updating user: {Email}", command.Email);
            return "Unexpected server error. Please try again later.";
        }
    }
}