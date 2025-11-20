using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.CreateProduct;

public record CreateProductCommand(CreateProductDto ProductDto, string? CreatedBy): ICommand<BaseResponse<string>>;