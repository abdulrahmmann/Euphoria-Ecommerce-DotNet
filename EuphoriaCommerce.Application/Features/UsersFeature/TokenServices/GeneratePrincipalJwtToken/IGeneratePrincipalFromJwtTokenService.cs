using System.Security.Claims;

namespace EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GeneratePrincipalJwtToken;

public interface IGeneratePrincipalFromJwtTokenService
{
    ClaimsPrincipal GetPrincipalFromJwtToken(string? token);
}