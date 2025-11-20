using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.RestoreProduct;

public record RestoreProductCommand(Guid ProductId, string? RestoredBy): ICommand<BaseResponse<string>>;