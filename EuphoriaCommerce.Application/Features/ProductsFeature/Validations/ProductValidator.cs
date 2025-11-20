using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using FluentValidation;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Validations;

public class ProductValidator: AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(120).WithMessage("Product name cannot exceed 120 characters");
        
        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Product Description cannot be empty")
            .MaximumLength(1000).WithMessage("Product Description cannot exceed 1000 characters");

        RuleFor(product => product.Price)
            .PrecisionScale(18, 2, true).WithMessage("Product Price Precision Scale must be 18,2");
        
        RuleFor(product => product.CategoryName)
            .NotEmpty().WithMessage("Product Category Name cannot be empty")
            .MaximumLength(60).WithMessage("Product Category Name cannot exceed 60 characters");
        
        RuleFor(product => product.SubCategoryName)
            .NotEmpty().WithMessage("Product Sub Category Name cannot be empty")
            .MaximumLength(60).WithMessage("Product Sub Category Name cannot exceed 60 characters");
        
        RuleFor(product => product.BrandName)
            .NotEmpty().WithMessage("Product Brand Name cannot be empty")
            .MaximumLength(120).WithMessage("Product Brand Name cannot exceed 120 characters");
    }
}