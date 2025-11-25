using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsers;

public record GetUsersQuery(): IQuery<UserResponse<List<UserDto2>>>;