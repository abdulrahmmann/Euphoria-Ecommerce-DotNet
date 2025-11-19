using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class BrandRepository(ApplicationDbContext dbContext): IBrandRepository
{
    public async Task<List<Brand>> GetBrands(CancellationToken cancellationToken)
    {
        return await dbContext.Brands.ToListAsync(cancellationToken);
    }

    public async Task AddBrand(Brand category, CancellationToken cancellationToken)
    {
        var brandToAdd = await dbContext.Brands.FirstOrDefaultAsync(c => c.Name == category.Name, cancellationToken);
        
        if (brandToAdd != null) return;
        
        await dbContext.Brands.AddAsync(brandToAdd!, cancellationToken);
    }
}