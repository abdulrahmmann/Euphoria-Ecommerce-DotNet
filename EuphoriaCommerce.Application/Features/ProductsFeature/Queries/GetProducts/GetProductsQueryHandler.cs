using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Infrastructure.UOF;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EuphoriaCommerce.Application.Features.ProductsFeature.Queries.GetProducts;

public class GetProductsQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
    : IQueryHandler<GetProductsQuery, BaseResponse<List<ProductDto>>>
{
    public async Task<BaseResponse<List<ProductDto>>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            var productRepo = unitOfWork.GetProductRepo.GetProducts();
            
            var products = await productRepo.Select(x => new ProductDto(x.Id, x.Name, x.Description, x.Price, 
                x.TotalStock, x.Category.Name, x.SubCategory.Name, x.Brand.Name)).ToListAsync(cancellationToken);

            if (products.Count == 0)
            {
                logger.Information("No Products  Found");
                return BaseResponse<List<ProductDto>>.NoContent("No Products Found");
            }
            
            return BaseResponse<List<ProductDto>>.Success(products);
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<List<ProductDto>>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}