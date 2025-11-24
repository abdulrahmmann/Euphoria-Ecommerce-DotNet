using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Queries.GetUserRole;

public record GetUserRolesByEmailQuery(string Email): IQuery<string>;