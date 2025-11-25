using Microsoft.AspNetCore.Http;

namespace EuphoriaCommerce.Application.Features.UsersFeature.DTOs;

public record CreateUserWithProfileDto( 
    string Email, 
    string Username, 
    string Password, 
    string ConfirmPassword, 
    string Role, 
    
    string? FirstName, 
    string? SecondName, 
    string? LastName, 
    string? Bio, 
    string? Gender, 
    string? Country, 
    string? City, 
    string? Street, 
    string? ZipCode,
    
    // upload image
    IFormFile ProfileImageUrl 
);