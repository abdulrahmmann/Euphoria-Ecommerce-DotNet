using EuphoriaCommerce.Application.Features.UsersFeature.DTOs;
using FluentValidation;

namespace EuphoriaCommerce.Application.Features.UsersFeature.Validations;

public class RegisterUserValidator: AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(temp => temp.Email)
            .EmailAddress().WithMessage("Invalid email format")
            .NotEmpty().WithMessage("Email must not be empty.")
            .NotNull().WithMessage("Email must not be null");
        
        RuleFor(temp => temp.Username)
            .MinimumLength(6).WithMessage("UserName name must be at least 6 characters long.")
            .MaximumLength(60).WithMessage("UserName name cannot exceed 60 characters.")
            .NotEmpty().WithMessage("UserName must not be empty.")
            .NotNull().WithMessage("UserName must not be null");
        
        RuleFor(temp => temp.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
            .NotEmpty().WithMessage("Password must not be empty.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("Password must contain uppercase, lowercase, number, and special character.");
        
        RuleFor(temp => temp.ConfirmPassword)
            .MinimumLength(8).WithMessage("Confirm Password must be at least 8 characters long.")
            .MaximumLength(100).WithMessage("Confirm Password cannot exceed 100 characters.")
            .NotEmpty().WithMessage("Confirm Password must not be empty.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("Confirm Password must contain uppercase, lowercase, number, and special character.")
            .Equal(temp => temp.Password).WithMessage("Password and Confirm Password does not matched."); 
    }
}