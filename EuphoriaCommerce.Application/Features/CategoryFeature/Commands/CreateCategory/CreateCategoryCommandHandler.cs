// using EuphoriaCommerce.Application.Common;
// using EuphoriaCommerce.Domain.CQRS;
// using EuphoriaCommerce.Domain.Entities.CatalogDomain;
// using EuphoriaCommerce.Infrastructure.UOF;
// using Serilog;
//
// namespace EuphoriaCommerce.Application.Features.CategoryFeature.Commands.CreateCategory;
//
// public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ILogger logger)
//     : ICommandHandler<CreateCategoryCommand, BaseResponse<string>>
// {
//     public async Task<BaseResponse<string>> HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken = default)
//     {
//         var request = command.CategoryDto;
//         
//         try
//         { 
//             var exists  = await unitOfWork.GetCategoriesRepo.ExistsAsync(p => p.Name.ToLower() == request.Name.ToLower(), cancellationToken);
//             
//             if (exists)
//             {
//                 logger.Warning("Category already exists");
//                 return BaseResponse<string>.Conflict("Category already exists");
//             }
//
//             var category = new Category(request.Name, request.Description);
//
//             await unitOfWork.GetCategoriesRepo.AddCategory(category, cancellationToken);
//             
//             await unitOfWork.SaveChangesAsync(cancellationToken);
//             
//             return BaseResponse<string>.Created($"Category with name: {request.Name} was created");
//         }
//         catch (Exception e)
//         {
//             logger.Error("Unexpected Error : {error}", e.Message);
//             return BaseResponse<string>.InternalError($"{e.Message}, {e.Data}");
//         }
//     }
// }