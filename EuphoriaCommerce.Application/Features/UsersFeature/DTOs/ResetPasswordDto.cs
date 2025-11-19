namespace EuphoriaCommerce.Application.Features.UsersFeature.DTOs;

public record ResetPasswordDto(string Email, string NewPassword, string Token);