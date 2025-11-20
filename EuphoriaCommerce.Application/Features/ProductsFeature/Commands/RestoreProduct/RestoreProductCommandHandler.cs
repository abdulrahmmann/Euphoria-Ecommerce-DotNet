using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Infrastructure.UOF;
using Serilog;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.RestoreProduct;

public class RestoreProductCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
    :ICommandHandler<RestoreProductCommand, BaseResponse<string>> 
{
    public async Task<BaseResponse<string>> HandleAsync(RestoreProductCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var exist = await unitOfWork.GetProductRepo.ExistsAsync(x => x.Id == command.ProductId, cancellationToken);

            if (!exist)
            {
                logger.Warning("Product does not exists");
                return BaseResponse<string>.Conflict("Product does not exists");
            }
            
            var product = await unitOfWork.GetProductRepo.GetProductById(command.ProductId, cancellationToken);

            if (product?.IsDeleted == false)
            {
                logger.Warning($"Product with Id: {command.ProductId} is not deleted");
                return BaseResponse<string>.BadRequest($"Product with Id: {command.ProductId} is not deleted");
            }
            
            await unitOfWork.GetProductRepo.RestoreProduct(command.ProductId, cancellationToken, command.RestoredBy);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return BaseResponse<string>.Success($"Product with Id: {command.ProductId} was restored");
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<string>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}