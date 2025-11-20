using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductVariantRepository(ApplicationDbContext dbContext): IProductVariantRepository
{
    public IQueryable<ProductVariant?> GetProductVariants()
    {
        return dbContext.ProductVariants.AsNoTracking()
            .Include(p => p.Product)
            .Include(clr => clr.Color)
            .Include(sz => sz.Size)
            .OrderBy(variant => variant.Product.Name)
            .ThenBy(variant => variant.Stock)
            .AsSplitQuery();
    }
    
    public IQueryable<ProductVariant?> FilterVariantsByCondition(Expression<Func<ProductVariant, bool>> predicate)
    {
        return dbContext.ProductVariants.AsNoTracking()
            .Include(p => p.Product)
            .Include(clr => clr.Color)
            .Include(sz => sz.Size)
            .AsSplitQuery()
            .OrderBy(variant => variant.Product.Name)
            .ThenBy(variant => variant.Stock)
            .Where(predicate);
    }
    
    public async Task AddProductVariant(ProductVariant variant, CancellationToken cancellationToken, string? createdBy = null)
    {
        var variantToAdd = ProductVariant.Create(variant.Stock, variant.PriceOverride, variant.ProductId, variant.ColorId, variant.SizeId, createdBy);
        
        await dbContext.ProductVariants.AddAsync(variantToAdd, cancellationToken);
    }

    public async Task UpdateProductVariant(Guid id, ProductVariant variant, CancellationToken cancellationToken, string? modifiedBy = null)
    {
        var variantToUpdate = await dbContext.ProductVariants.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToUpdate?.Update(variant.Stock, variant.PriceOverride, variant.ProductId, variant.ColorId, variant.SizeId, modifiedBy);
    }

    public async Task DeleteProductVariant(Guid id, CancellationToken cancellationToken, string? deletedBy = null)
    {
        var variantToDelete = await dbContext.ProductVariants.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToDelete?.Delete(deletedBy);
    }
    
    public async Task RestoreProductVariant(Guid id, CancellationToken cancellationToken, string? restoredBy = null)
    {
        var variantToRestore = await dbContext.ProductVariants.SingleOrDefaultAsync(v => v.Id == id, cancellationToken);

        variantToRestore?.Restore(restoredBy);
    }
}