namespace EuphoriaCommerce.Application.Features.UsersFeature.DTOs;

public record RegisterUserDto(string Email, string Username, string Password, string ConfirmPassword);