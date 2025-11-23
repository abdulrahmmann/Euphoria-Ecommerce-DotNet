using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface ITagRepository
{
    Task<List<ProductTag>> GetTags(CancellationToken cancellationToken);
    
    Task AddTag(ProductTag tag, CancellationToken cancellationToken);
    
    Task<ProductTag?> GetTagById(Guid id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Expression<Func<ProductTag, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> ExistsWithIgnoreQueryFilterAsync
        (Expression<Func<ProductTag, bool>> predicate, CancellationToken cancellationToken = default);
}