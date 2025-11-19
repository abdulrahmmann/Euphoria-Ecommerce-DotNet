using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductRepository
{
    public IQueryable<Product> GetProducts();
    
    IQueryable<Product?> GetProductByProductId(Guid id);
    
    Task AddProduct(Product product, CancellationToken cancellationToken, string? createdBy = null);
    
    Task UpdateProduct(Guid id, Product product, CancellationToken cancellationToken, string? modifiedBy = null);
    
    Task DeleteProduct(Guid id, CancellationToken cancellationToken, string? deletedBy = null);
    
    Task RestoreProduct(Guid id, CancellationToken cancellationToken, string? restoredBy = null);
    
    IQueryable<Product?> FilterProductByCondition(Expression<Func<Product, bool>>  predicate);
}