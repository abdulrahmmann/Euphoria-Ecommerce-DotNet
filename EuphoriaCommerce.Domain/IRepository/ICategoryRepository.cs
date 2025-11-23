using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategories(CancellationToken cancellationToken);
    
    Task AddCategory(Category category, CancellationToken cancellationToken);
    
    Task<Category?> GetCategoryById(Guid id, CancellationToken cancellationToken);
    
    Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> ExistsWithIgnoreQueryFilterAsync
        (Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken = default);
}