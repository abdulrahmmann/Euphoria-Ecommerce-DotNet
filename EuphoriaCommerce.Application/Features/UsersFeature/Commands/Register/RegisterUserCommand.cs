using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.Register;

public record RegisterUserCommand(RegisterUserDto UserDto): ICommand<AuthenticationResponse>;