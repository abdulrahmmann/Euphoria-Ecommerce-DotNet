using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class SubCategoryRepository(ApplicationDbContext dbContext): ISubCategoryRepository
{
    public IQueryable<SubCategory?> GetSubCategories()
    {
        return dbContext.SubCategories
            .AsNoTracking()
            .Include(sc => sc.Category)
            .OrderBy(sc => sc.Name);
    }

    public IQueryable<SubCategory?> FilterSubCategoryByCondition(Expression<Func<SubCategory, bool>> predicate)
    {
        return dbContext.SubCategories
            .AsNoTracking()
            .Include(sc => sc.Category)
            .Where(predicate)
            .OrderBy(sc => sc.Name);
    }
    
    public async Task AddSubCategory(SubCategory category, CancellationToken cancellationToken)
    {
        var subCategoryToAdd = await dbContext.SubCategories.FirstOrDefaultAsync(c => c.Name == category.Name, cancellationToken);
        
        if (subCategoryToAdd != null) return;
        
        await dbContext.SubCategories.AddAsync(subCategoryToAdd!, cancellationToken);
    }
}