using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategories(CancellationToken cancellationToken);
    
    Task AddCategory(Category category, CancellationToken cancellationToken);
}