using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.UsersFeature.Models;
using EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateRefreshToken;
using EuphoriaCommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EuphoriaCommerce.Application.Features.UsersFeature.TokenServices.GenerateToken;

public class GenerateTokenService(
    IGenerateRefreshTokenService refreshTokenService, 
    UserManager<ApplicationUser> userManager, 
    IConfiguration  configuration
    ) : IGenerateTokenService
{

    #region Generate Token Method.
    public AuthenticationResponse GenerateToken(ApplicationUser user)
    {
        // Jwt Info from app-settings.json file
        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()!;
        
        // Token Expiration Minutes.
        var expirationToken = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings.ExpirationMinutes));
        
        // Get user role.
        var userRole = userManager.GetRolesAsync(user).Result.FirstOrDefault();
        
        // Get Secret Key.
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        
        // Create Signing Credentials.
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        
        // Create User Claims.
        var claims = new Claim[]
        {
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Email, user.Email!),
            new (JwtRegisteredClaimNames.UniqueName, user.UserName!),
            new (JwtRegisteredClaimNames.Gender, user.Gender),
            new (JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber!),
            new (ClaimTypes.Role, userRole ?? "User")
        };
        
        // Generate Token.
        var tokenGenerator = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: expirationToken,
            signingCredentials: signingCredentials
            );
        
        // Write Token.
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var token = tokenHandler.WriteToken(tokenGenerator);
        
        // Return AuthenticationResponse.
        return AuthenticationResponse.Success(
            userId:user.Id,
            username: user.UserName!,
            email: user.Email!,
            token: token,
            refreshToken: refreshTokenService.GenerateRefreshToken(),
            refreshTokenExpiration: DateTime.Now.AddMinutes(Convert.ToInt64(configuration["RefreshToken:ExpirationMinutes"])),
            expiration: expirationToken,
            message: "Token Generated Successfully"
            );
    }
    #endregion
}