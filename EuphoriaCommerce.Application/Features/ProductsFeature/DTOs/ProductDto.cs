namespace EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;

public record ProductDto(Guid Id, string Name, string Description, decimal Price,  int TotalStock,
    string CategoryName, string GenderCategoryName, string BrandName);