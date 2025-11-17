using EuphoriaCommerce.Application.Common;

namespace EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;

public interface IGenerateTokenService
{
    AuthenticationResponse GenerateToken(ApplicationUser user);
}