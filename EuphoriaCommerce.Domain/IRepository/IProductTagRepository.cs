using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductTagRepository
{
    Task<List<ProductTag>> GetTags(CancellationToken cancellationToken);
    
    Task AddBrand(ProductTag tag, CancellationToken cancellationToken);
}