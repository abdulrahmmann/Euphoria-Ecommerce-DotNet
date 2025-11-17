using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.IdentityEntities;

namespace EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;

public interface IGenerateTokenService
{
    AuthenticationResponse GenerateToken(ApplicationUser user);
}