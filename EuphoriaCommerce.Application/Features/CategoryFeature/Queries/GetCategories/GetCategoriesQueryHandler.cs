using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.CategoryFeature.DTOs;
using EuphoriaCommerce.Domain.CQRS;
using EuphoriaCommerce.Infrastructure.UOF;
using Serilog;

namespace EuphoriaCommerce.Application.Features.CategoryFeature.Queries.GetCategories;

public class GetCategoriesQueryHandler(IUnitOfWork unitOfWork, ILogger logger)
    : IQueryHandler<GetCategoriesQuery, BaseResponse<List<CategoryDto>>>
{
    public async Task<BaseResponse<List<CategoryDto>>> HandleAsync(GetCategoriesQuery query, CancellationToken cancellationToken = default)
    {
        try
        {
            var categoriesRepo = await unitOfWork.GetCategoriesRepo.GetCategories(cancellationToken);

            if (categoriesRepo.Count == 0)
            {
                logger.Information("No categories found");
                return BaseResponse<List<CategoryDto>>.NoContent("No categories found");
            }

            var categories = categoriesRepo.Select(x => new CategoryDto(x.Id, x.Name, x.Description)).ToList();
            
            return BaseResponse<List<CategoryDto>>.Success(data:categories, totalCount: categories.Count);
        }
        catch (Exception e)
        {
            logger.Error("Unexpected Error : {error}", e.Message);
            return BaseResponse<List<CategoryDto>>.InternalError($"{e.Message}, {e.Data}");
        }
    }
}