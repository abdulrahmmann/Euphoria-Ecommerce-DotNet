using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.UpdateProduct;

public record UpdateProductCommand(Guid ProductId, UpdateProductDto ProductDto, string? ModifyBy): ICommand<BaseResponse<string>>;