using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Infrastructure.UOF;
using Serilog;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IUnitOfWork unitOfWork, ILogger logger) 
    : ICommandHandler<UpdateProductCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> HandleAsync(UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        var request = command.ProductDto;
        
        try
        {
            var exists  = await unitOfWork.GetProductRepo.ExistsAsync(p => p.Id == command.ProductId, cancellationToken);
            
            if (!exists)
            {
                logger.Warning("Product does not exists");
                return BaseResponse<string>.Conflict("Product does not exists");
            }
            
            var isNameExist = await unitOfWork.GetProductRepo
                .ExistsAsync(p => p.Name == request.Name && p.Id != command.ProductId, cancellationToken);
            
            if (isNameExist)
            {
                logger.Warning("Product name already exists");
                return BaseResponse<string>.BadRequest("Product name already exists");
            }
            
            var productToUpdate = await unitOfWork.GetProductRepo.GetProductById(command.ProductId, cancellationToken);
            
            productToUpdate?.Update(
                request.Name,
                request.Description,
                request.Price,
                request.TotalStock,
                request.CategoryId,
                request.SubCategoryId,
                request.BrandId,
                command.ModifyBy
            );

            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return BaseResponse<string>.Success($"Product with name: {request.Name} was updated");
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<string>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}