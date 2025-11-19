using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class SubCategoryRepository(ApplicationDbContext dbContext): ISubCategoryRepository
{
    public async Task<List<SubCategory>> GetSubCategories(CancellationToken cancellationToken)
    {
        return await dbContext.SubCategories.Include(sc => sc.Category).ToListAsync(cancellationToken);
    }

    public async Task AddSubCategory(SubCategory category, CancellationToken cancellationToken)
    {
        var subCategoryToAdd = await dbContext.SubCategories.FirstOrDefaultAsync(c => c.Name == category.Name, cancellationToken);
        
        if (subCategoryToAdd != null) return;
        
        await dbContext.SubCategories.AddAsync(subCategoryToAdd!, cancellationToken);
    }
}