using System.Net;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsersByRole;

public class GetUsersByRoleQueryHandler(UserManager<ApplicationUser> userManager, ILogger logger)
    : IQueryHandler<GetUsersByRoleQuery, IEnumerable<UserDto2>>
{
    public async Task<IEnumerable<UserDto2>> HandleAsync(GetUsersByRoleQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(query.Role))
            {
                logger.Error("Role is required");
                return new List<UserDto2>();
            }

            if (query.Role != "User" || query.Role != "Admin")
            {
                logger.Error("Role is required");
                return new List<UserDto2>();
            }
            
            var users = await userManager.GetUsersInRoleAsync(query.Role);

            if (users.Count == 0)
            {
                logger.Error("Users are empty");
                return new List<UserDto2>();
            }
            
            var usersMapped = users.Select(x => new UserDto2(x.Id, x.UserName, x.Email, x.PhoneNumber, x.Role, x.IsActive,
                x.JoinedDate, x.UserProfile?.ProfileImageUrl));

            return usersMapped;
        }
        catch (Exception e)
        {
            logger.Error(e, "Unexpected error while retrieving users");
            return [];
        }
    }
}