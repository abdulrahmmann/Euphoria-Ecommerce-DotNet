using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductBadgeRepository(ApplicationDbContext dbContext): IProductBadgeRepository
{
    public async Task<List<ProductBadge>> GetProductBadges(CancellationToken cancellationToken)
    {
        return await dbContext.ProductBadges.ToListAsync(cancellationToken);
    }

    public async Task AddProductBadge(ProductBadge productBadge, CancellationToken cancellationToken)
    {
        var badgeToAdd = await dbContext.ProductBadges.FirstOrDefaultAsync(c => c.Name == productBadge.Name, cancellationToken);
        
        if (badgeToAdd != null) return;
        
        await dbContext.ProductBadges.AddAsync(badgeToAdd!, cancellationToken);
    }
}