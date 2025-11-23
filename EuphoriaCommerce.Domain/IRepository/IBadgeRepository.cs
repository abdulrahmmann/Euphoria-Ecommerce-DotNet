using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface IBadgeRepository
{
    Task<List<ProductBadge>> GetBadges(CancellationToken cancellationToken);
    
    Task AddBadge(ProductBadge tag, CancellationToken cancellationToken);
    
    Task<ProductBadge?> GetBadgeById(Guid id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Expression<Func<ProductBadge, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> ExistsWithIgnoreQueryFilterAsync
        (Expression<Func<ProductBadge, bool>> predicate, CancellationToken cancellationToken = default);
}