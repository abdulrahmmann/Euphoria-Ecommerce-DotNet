using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.CreateUser;

public record CreateUserWithProfileCommand(CreateUserWithProfileDto UserWithProfileDto): ICommand<AuthenticationResponse>;