using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.IRepository;

public interface ISubCategoryRepository
{
    IQueryable<SubCategory?> GetSubCategories();
    
    IQueryable<SubCategory?> FilterSubCategoryByCondition(Expression<Func<SubCategory, bool>>  predicate);
    
    Task AddSubCategory(SubCategory category, CancellationToken cancellationToken);
}