using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductVariantRepository
{
    Task<List<ProductVariant>> GetProductVariants(CancellationToken cancellationToken);
    Task<ProductVariant?> GetProductVariantByProductId(Guid id, CancellationToken cancellationToken);
    Task AddProductVariant(ProductVariant variant, CancellationToken cancellationToken, string? createdBy = null);
    Task UpdateProductVariant(Guid id, ProductVariant variant, CancellationToken cancellationToken, string? modifiedBy = null);
    Task DeleteProductVariant(Guid id, CancellationToken cancellationToken, string? deletedBy = null);
    Task RestoreProductVariant(Guid id, CancellationToken cancellationToken, string? restoredBy = null);
    
    Task<ProductVariant?> FilterVariantByCondition(Expression<Func<ProductVariant, bool>>  predicate, CancellationToken cancellationToken);
    
    IQueryable<ProductVariant> FilterVariantsByCondition(Expression<Func<ProductVariant, bool>>  predicate);
}