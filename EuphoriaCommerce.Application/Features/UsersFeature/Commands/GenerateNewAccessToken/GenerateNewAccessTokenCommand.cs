using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Commands.GenerateNewAccessToken;

public record GenerateNewAccessTokenCommand(TokenModel TokenModel): ICommand<AuthenticationResponse>;