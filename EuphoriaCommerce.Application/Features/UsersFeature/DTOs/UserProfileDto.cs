namespace EuphoriaCommerce.Application.Features.UsersFeature.DTOs;

public record UserProfileDto(string? FirstName, string? SecondName, string? LastName, string? ProfileImageUrl, 
    string? Bio, string? Gender, string? Country, string? City, string? Street, string? ZipCode)
{
    public string FullName => $"{FirstName} {SecondName} {LastName}".Replace("  ", " ").Trim();
};