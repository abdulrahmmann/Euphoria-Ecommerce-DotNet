using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.DeleteProduct;

public record DeleteProductCommand(Guid ProductId, string? DeletedBy): ICommand<BaseResponse<string>>;