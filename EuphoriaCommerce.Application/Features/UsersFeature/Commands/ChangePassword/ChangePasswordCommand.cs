using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.ChangePassword;

public record ChangePasswordCommand(string Email, ChangePasswordDto PasswordDto) : ICommand<AuthenticationResponse>;