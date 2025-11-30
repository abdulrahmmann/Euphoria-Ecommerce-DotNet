using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;
using EuphoriaCommerce.Application.Helpers;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.CreateUser;

public class CreateUserWithProfileCommandHandler(
    UserManager<ApplicationUser> userManager, 
    ILogger logger,
    RoleManager<IdentityRole> roleManager,
    IGenerateTokenService tokenService, 
    IValidator<CreateUserWithProfileDto> validator,
    CloudinaryService cloudinaryService
    ) : ICommandHandler<CreateUserWithProfileCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> HandleAsync(CreateUserWithProfileCommand withProfileCommand, CancellationToken cancellationToken = default)
    {
        var request = withProfileCommand.UserWithProfileDto;
        
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return AuthenticationResponse.Failure("Validation failed.", validationErrors, HttpStatusCode.UnprocessableEntity);
        }
        
        try
        {
            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return AuthenticationResponse.Failure("Email is already registered.", statusCode: HttpStatusCode.Conflict);

            if (await userManager.FindByNameAsync(request.Username) is not null)
                return AuthenticationResponse.Failure("Username is already taken.", statusCode: HttpStatusCode.Conflict);

            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Username,
                Role = request.Role,
            };
            
            var profileImageUrl = await cloudinaryService.UploadProfileImageAsync(request.ProfileImageUrl);
            
            var newUserProfile = new UserProfile(
                firstName: request.FirstName,
                secondName: request.SecondName,
                lastName: request.LastName,
                profileImageUrl: profileImageUrl,
                bio: request.Bio,
                gender: request.Gender,
                country: request.Country,
                city: request.City,
                street: request.Street,
                zipCode: request.ZipCode,
                userId: newUser.Id
                );
            
            newUser.UpdateUserProfile(newUserProfile);
            
            var identityResult = await userManager.CreateAsync(newUser, request.Password);
            
            if (!identityResult.Succeeded)
            {
                var createErrors = identityResult.Errors.Select(e => e.Description).ToList();
                return AuthenticationResponse.Failure("User creation failed.", createErrors);
            }
            
            if (!await roleManager.RoleExistsAsync(request.Role))
            {
                logger.Information("Role {Role} does not exist. Creating it.", request.Role);
                await roleManager.CreateAsync(new IdentityRole(request.Role));
            }
            
            var roleResult = await userManager.AddToRoleAsync(newUser, request.Role);
            if (!roleResult.Succeeded)
            {
                logger.Warning("Failed to assign role {Role} to user {Username}",request.Role, newUser.UserName);
            }

            newUser.SetRole(request.Role);
            
            var tokenResponse = tokenService.GenerateToken(newUser);
            newUser.SetRefreshToken(tokenResponse.RefreshToken);
            newUser.SetRefreshTokenExpiration(tokenResponse.RefreshTokenExpiration);

            await userManager.UpdateAsync(newUser);

            return tokenResponse;
        }
        catch (Exception e)
        {
            logger.Error(e, "Error while creating user");
            return AuthenticationResponse.Failure($"Unexpected server error. Please try again later: {e.Message}");
        }
    }

    // private async Task<string?> UploadProfileImageAsync(IFormFile? file)
    // {
    //     if (file == null || file.Length == 0)
    //         return null;
    //
    //     var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile-images");
    //     if (!Directory.Exists(uploadsFolder))
    //         Directory.CreateDirectory(uploadsFolder);
    //
    //     var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
    //     var filePath = Path.Combine(uploadsFolder, uniqueFileName);
    //
    //     using (var fileStream = new FileStream(filePath, FileMode.Create))
    //     {
    //         await file.CopyToAsync(fileStream);
    //     }
    //
    //     return $"/profile-images/{uniqueFileName}";
    // }
}
