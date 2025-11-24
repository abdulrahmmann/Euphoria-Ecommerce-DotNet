using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.UpdateUserProfile;

public record UpdateUserProfileCommand(string? Email, UserProfileDto UserProfileDto): ICommand<string>;