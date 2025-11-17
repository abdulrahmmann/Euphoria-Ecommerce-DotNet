using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using FluentValidation;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Validations;

public class LoginUserValidator: AbstractValidator<LoginUserDto>
{
    public LoginUserValidator()
    {
        RuleFor(temp => temp.Email)
            .EmailAddress().WithMessage("Invalid email format")
            .NotEmpty().WithMessage("Email must not be empty.")
            .NotNull().WithMessage("Email must not be null");
        
        RuleFor(temp => temp.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
            .NotEmpty().WithMessage("Password must not be empty.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("Password must contain uppercase, lowercase, number, and special character.");
    }
}