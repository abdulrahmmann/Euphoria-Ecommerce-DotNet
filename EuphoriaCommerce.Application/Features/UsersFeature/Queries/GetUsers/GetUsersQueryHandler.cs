using System.Net;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsers;

public class GetUsersQueryHandler(UserManager<ApplicationUser> userManager, ILogger logger)
    : IQueryHandler<GetUsersQuery, UserResponse<IEnumerable<UserDto2>>>
{
    public async Task<UserResponse<IEnumerable<UserDto2>>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = userManager.Users.ToList(); 

            if (users.Count == 0)
            {
                logger.Error("Users are empty");
                return UserResponse<IEnumerable<UserDto2>>.Failure("Users are empty", HttpStatusCode.NoContent);
            }
            
            var userList = new List<UserDto2>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault() ?? "User";
                
                userList.Add(new UserDto2(
                    user.Id,
                    user.UserProfile?.FullName,
                    user.Email,
                    user.PhoneNumber,
                    roleName,
                    user.IsActive,
                    user.JoinedDate,
                    user.UserProfile?.ProfileImageUrl
                ));
            }

            return UserResponse<IEnumerable<UserDto2>>
                .Success(
                    totalCount: userList.Count,
                    httpStatusCode: HttpStatusCode.OK,
                    message: "Users retrieved successfully",
                    data: userList
                );
        }
        catch (Exception e)
        {
            logger.Error(e, "Unexpected error while retrieving users");
            return UserResponse<IEnumerable<UserDto2>>
                .Failure("Unexpected server error. Please try again later.", HttpStatusCode.InternalServerError);
        }
    }
}