using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Infrastructure.UOF;
using FluentValidation;
using Serilog;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Commands.CreateProduct;

public class CreateProductCommandHandler(
    IUnitOfWork unitOfWork, IValidator<CreateProductDto> validator, ILogger logger
    ): ICommandHandler<CreateProductCommand, BaseResponse<string>>
{
    public async Task<BaseResponse<string>> HandleAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var request = command.ProductDto;
        
        try
        {
            var exists  = await unitOfWork.GetProductRepo
                .ExistsAsync(p => p.Name.ToLower() == request.Name.ToLower(), cancellationToken);

            if (exists )
            {
                logger.Warning("Product already exists");
                return BaseResponse<string>.Conflict("Product already exists");
            }

            var product = Product.Create(request.Name, request.Description, request.Price, request.TotalStock, request.CategoryId, 
                request.SubCategoryId, request.BrandId, command.CreatedBy);

            await unitOfWork.GetProductRepo.AddProduct(product, cancellationToken);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return BaseResponse<string>.Created($"Product with name: {request.Name} was created");
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<string>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}