using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class CategoryRepository(ApplicationDbContext dbContext): ICategoryRepository
{
    public async Task<List<Category>> GetCategories(CancellationToken cancellationToken)
    {
        return await dbContext.Categories.ToListAsync(cancellationToken);
    }

    public async Task AddCategory(Category category, CancellationToken cancellationToken)
    {
        var categoryToAdd = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name, cancellationToken);
        
        if (categoryToAdd != null) return;
        
        await dbContext.Categories.AddAsync(categoryToAdd!, cancellationToken);
    }
}