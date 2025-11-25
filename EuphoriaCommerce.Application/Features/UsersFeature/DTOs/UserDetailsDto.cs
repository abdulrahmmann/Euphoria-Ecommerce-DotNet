namespace EuphoriaCommerce.Application.Features.UsersFeature.DTOs;

public record UserDto2(string Id, string? UserName, string? Email, string? PhoneNumber, 
    string Role, bool IsActive, DateTime JoinedDate, string? ProfileImageUrl);