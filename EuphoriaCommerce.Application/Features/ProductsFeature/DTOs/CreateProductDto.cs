namespace EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;

public record CreateProductDto(string Name, string Description, decimal Price,  int TotalStock,
    Guid CategoryId, Guid SubCategoryId, Guid BrandId);