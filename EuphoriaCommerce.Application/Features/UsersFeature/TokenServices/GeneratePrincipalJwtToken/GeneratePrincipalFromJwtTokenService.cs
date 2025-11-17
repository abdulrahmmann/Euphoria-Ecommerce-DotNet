using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GeneratePrincipalJwtToken;

public class GeneratePrincipalFromJwtTokenService(IConfiguration configuration): IGeneratePrincipalFromJwtTokenService
{
    public ClaimsPrincipal GetPrincipalFromJwtToken(string? token)
    {
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()!;
        
        var tokenValidation = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false,
            
            ValidAudience = configuration["Jwt:Audience"],
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SECRET_KEY"]!)),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var principal = tokenHandler.ValidateToken(token, tokenValidation, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }
        return principal;
    }
}