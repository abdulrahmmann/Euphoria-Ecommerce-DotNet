using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Infrastructure.UOF;
using Serilog;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
    : ICommandHandler<DeleteProductCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var exist = await unitOfWork.GetProductRepo.ExistsAsync(x => x.Id == command.ProductId, cancellationToken);

            if (!exist)
            {
                logger.Warning("Product does not exists");
                return BaseResponse<string>.Conflict("Product does not exists");
            }
            
            await unitOfWork.GetProductRepo.DeleteProduct(command.ProductId, cancellationToken, command.DeletedBy);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return BaseResponse<string>.Success($"Product with Id: {command.ProductId} was deleted");
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<string>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}