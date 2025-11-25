using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Serilog;
using StackExchange.Redis;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsersByRole;

public class GetUsersByRoleQueryHandler(UserManager<ApplicationUser> userManager, ILogger logger)
    : IQueryHandler<GetUsersByRoleQuery, UserResponse<List<UserDto2>>>
{
    public async Task<UserResponse<List<UserDto2>>> HandleAsync(GetUsersByRoleQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(query.Role))
            {
                logger.Error("Role is required");
                return UserResponse<List<UserDto2>>.Failure("Role is required", HttpStatusCode.BadRequest);
            }

            if (query.Role.ToLower().Trim() != "user" && query.Role.ToLower().Trim() != "admin")
            {
                logger.Error("Role is required");
                return UserResponse<List<UserDto2>>.Failure("Role is required", HttpStatusCode.BadRequest);
            }
            
            var users = await userManager.GetUsersInRoleAsync(query.Role);

            if (users.Count == 0)
            {
                logger.Error("Users are empty");
               return UserResponse<List<UserDto2>>.Failure("Users are empty", HttpStatusCode.NoContent);
            }
            
            var usersMapped = users.Select(x => new UserDto2(x.Id, x.UserName, x.Email, x.PhoneNumber, x.Role, x.IsActive,
                x.JoinedDate, x.UserProfile?.ProfileImageUrl)).ToList();

            return UserResponse<List<UserDto2>>
                .Success(totalCount:usersMapped.Count(), httpStatusCode:HttpStatusCode.Accepted, message:"", data:usersMapped);
        }
        catch (Exception e)
        {
            logger.Error(e, "Unexpected error while retrieving users");
            return UserResponse<List<UserDto2>>.Failure("Unexpected error while retrieving users");
        }
    }
}