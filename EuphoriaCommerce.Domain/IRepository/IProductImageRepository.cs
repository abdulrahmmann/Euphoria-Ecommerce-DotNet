using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductImageRepository
{
    Task<List<ProductImage>> GetProductImages(CancellationToken cancellationToken);
    
    Task AddProductImage(ProductImage productImage, CancellationToken cancellationToken);
}