using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IProductBadgeRepository
{
    Task<List<ProductBadge>> GetProductBadges(CancellationToken cancellationToken);
    
    Task AddProductBadge(ProductBadge productBadge, CancellationToken cancellationToken);
}