using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace EuphoriaCommerce.Infrastructure.UOF;

public class UnitOfWork(ApplicationDbContext dbContext, 
    ICategoryRepository getCategoriesRepo, IBrandRepository getBrandsRepo, 
    IProductBadgeRepository getProductBadgesRepo, IProductTagRepository getTagsBadgesRepo, 
    IProductImageRepository getProductImagesRepo, IProductVariantRepository getProductVariantsRepo, 
    IProductRepository getProductRepo
    ): IUnitOfWork
{
    public ICategoryRepository GetCategoriesRepo { get; } = getCategoriesRepo;
    public IBrandRepository GetBrandsRepo { get; } = getBrandsRepo;
    public IProductBadgeRepository GetProductBadgesRepo { get; } = getProductBadgesRepo;
    public IProductTagRepository GetTagsBadgesRepo { get; } = getTagsBadgesRepo;
    public IProductImageRepository GetProductImagesRepo { get; } = getProductImagesRepo;
    public IProductVariantRepository GetProductVariantsRepo { get; } = getProductVariantsRepo;
    public IProductRepository GetProductRepo { get; } = getProductRepo;
    
    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
         return await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        dbContext.Dispose();
    }
}