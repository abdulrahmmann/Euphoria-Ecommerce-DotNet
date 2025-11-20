using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductVariantRepository
{
    /// <summary>Get All Products Variant with their relation properties.</summary>
    /// <returns>All Products Variant with fully details.</returns>
    public IQueryable<ProductVariant?> GetProductVariants();
    
    /// <summary>Get All Products Variant with their relation properties by a specific condition.</summary>
    /// <param name="predicate">The Condition.</param>
    /// <returns>All Products Variant with fully details.</returns>
    IQueryable<ProductVariant?> FilterVariantsByCondition(Expression<Func<ProductVariant, bool>>  predicate);
    
    /// <summary>Create a new Product Variant.</summary>
    /// <param name="variant">The new variant which wants to add it.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="createdBy">The admin who create the Product Variant.</param>
    Task AddProductVariant(ProductVariant variant, CancellationToken cancellationToken, string? createdBy = null);
    
    /// <summary>Update a Product Variant.</summary>
    /// <param name="id">The Product Variant ID.</param>
    /// <param name="variant">The variant which wants to replace the variant with it.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="modifiedBy">The admin who modify the Product Variant.</param>
    Task UpdateProductVariant(Guid id, ProductVariant variant, CancellationToken cancellationToken, string? modifiedBy = null);
    
    /// <summary>Delete a Product Variant.</summary>
    /// <param name="id">The Product Variant ID.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="deletedBy">The admin who delete the Product Variant.</param>
    Task DeleteProductVariant(Guid id, CancellationToken cancellationToken, string? deletedBy = null);
    
    /// <summary>Restore a Deleted Product Variant.</summary>
    /// <param name="id">The Product Variant ID.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="restoredBy">The admin who restore the Product Variant.</param>
    Task RestoreProductVariant(Guid id, CancellationToken cancellationToken, string? restoredBy = null);
}