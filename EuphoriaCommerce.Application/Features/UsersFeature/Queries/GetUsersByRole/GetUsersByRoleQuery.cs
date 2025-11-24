using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUsersByRole;

public record GetUsersByRoleQuery(string Role): IQuery<IEnumerable<UserDto2>>;