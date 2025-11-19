using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface ISubCategoryRepository
{
    Task<List<SubCategory>> GetSubCategories(CancellationToken cancellationToken);
    
    Task AddSubCategory(SubCategory category, CancellationToken cancellationToken);
}