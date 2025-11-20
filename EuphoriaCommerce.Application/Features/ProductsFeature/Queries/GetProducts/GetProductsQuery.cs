using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Queries.GetProducts;

public record GetProductsQuery(): IQuery<BaseResponse<List<ProductDto>>>;