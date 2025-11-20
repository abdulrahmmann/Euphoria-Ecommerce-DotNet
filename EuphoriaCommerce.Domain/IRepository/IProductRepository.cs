using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductRepository
{
    /// <summary>Get All Products with their relation properties.</summary>
    /// <returns>All Products with fully details.</returns>
    public IQueryable<Product?> GetProducts();
    
    /// <summary>Get All Products with their relation properties by a specific condition.</summary>
    /// <param name="predicate">The Condition.</param>
    /// <returns>All Products with fully details.</returns>
    IQueryable<Product?> FilterProductsByCondition(Expression<Func<Product, bool>>  predicate);
    
    /// <summary>Create a new Product.</summary>
    /// <param name="product">The new product which wants to add it.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="createdBy">The admin who create the Product.</param>
    Task AddProduct(Product product, CancellationToken cancellationToken, string? createdBy = null);
    
    /// <summary>Update a Product.</summary>
    /// <param name="id">The Product ID.</param>
    /// <param name="product">The product which wants to replace the variant with it.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="modifiedBy">The admin who modify the Product.</param>
    Task UpdateProduct(Guid id, Product product, CancellationToken cancellationToken, string? modifiedBy = null);
    
    /// <summary>Delete a Product.</summary>
    /// <param name="id">The Product ID.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="deletedBy">The admin who delete the Product.</param>
    Task DeleteProduct(Guid id, CancellationToken cancellationToken, string? deletedBy = null);
    
    /// <summary>Restore a Deleted Product.</summary>
    /// <param name="id">The Product ID.</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <param name="restoredBy">The admin who restore the Product.</param>
    Task RestoreProduct(Guid id, CancellationToken cancellationToken, string? restoredBy = null);
    
    Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default);
}