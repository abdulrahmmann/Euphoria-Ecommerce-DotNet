using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductVariantRepository(ApplicationDbContext dbContext): IProductVariantRepository
{
    public async Task<List<ProductVariant>> GetProductVariants(CancellationToken cancellationToken)
    {
        return await dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(c => c.Color)
            .Include(s => s.Size)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductVariant?> GetProductVariantByProductId(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.ProductVariants.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }
    
    public async Task AddProductVariant(ProductVariant variant, CancellationToken cancellationToken, string? createdBy = null)
    {
        var variantToAdd = ProductVariant.Create(variant.Stock, variant.PriceOverride, variant.ProductId, variant.ColorId, variant.SizeId, createdBy);
        
        await dbContext.ProductVariants.AddAsync(variantToAdd, cancellationToken);
    }

    public async Task UpdateProductVariant(Guid id, ProductVariant variant, CancellationToken cancellationToken, string? modifiedBy = null)
    {
        var variantToUpdate = await dbContext.ProductVariants.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToUpdate?.Update(variant.Stock, variant.PriceOverride, variant.ProductId, variant.ColorId, variant.SizeId, modifiedBy);
    }

    public async Task DeleteProductVariant(Guid id, CancellationToken cancellationToken, string? deletedBy = null)
    {
        var variantToDelete = await dbContext.ProductVariants.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToDelete?.Delete(deletedBy);
    }

    public async Task RestoreProductVariant(Guid id, CancellationToken cancellationToken, string? restoredBy = null)
    {
        var variantToRestore = await dbContext.ProductVariants.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToRestore?.Restore(restoredBy);
    }

    public async Task<ProductVariant?> FilterVariantByCondition(Expression<Func<ProductVariant, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(c => c.Color)
            .Include(s => s.Size)
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public IQueryable<ProductVariant> FilterVariantsByCondition(Expression<Func<ProductVariant, bool>> predicate)
    {
        return dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(c => c.Color)
            .Include(s => s.Size)
            .Where(predicate);
    }
}