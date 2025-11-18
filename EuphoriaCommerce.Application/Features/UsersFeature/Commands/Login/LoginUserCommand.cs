using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.Login;

public record LoginUserCommand(LoginUserDto UserDto): ICommand<AuthenticationResponse>;