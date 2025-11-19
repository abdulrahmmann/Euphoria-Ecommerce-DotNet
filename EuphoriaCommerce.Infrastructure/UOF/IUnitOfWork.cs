using EuphoriaCommerce.Domain.IRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace EuphoriaCommerce.Infrastructure.UOF;

public interface IUnitOfWork: IDisposable
{
    ICategoryRepository GetCategoriesRepo { get; }
    ISubCategoryRepository GetSubCategoriesRepo { get; }
    IBrandRepository GetBrandsRepo { get; }
    IProductBadgeRepository GetProductBadgesRepo { get; }
    IProductTagRepository GetTagsBadgesRepo { get; }
    IProductImageRepository GetProductImagesRepo { get; }
    IProductVariantRepository GetProductVariantsRepo { get; }
    IProductRepository GetProductRepo { get; }
    
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}