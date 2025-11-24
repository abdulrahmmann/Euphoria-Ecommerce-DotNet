using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class BadgeRepository(ApplicationDbContext dbContext): IBadgeRepository
{
    public async Task<List<ProductBadge>> GetBadges(CancellationToken cancellationToken)
    {
        return await dbContext.ProductBadges.AsNoTracking().Include(p => p.Product).ToListAsync(cancellationToken);
    }

    public async Task AddBadge(ProductBadge tag, CancellationToken cancellationToken)
    {
        var badgeToAdd = await dbContext.ProductBadges.FirstOrDefaultAsync(c => c.Name == tag.Name, cancellationToken);
        
        if (badgeToAdd != null) return;
        
        await dbContext.ProductBadges.AddAsync(badgeToAdd!, cancellationToken);
    }

    public async Task<ProductBadge?> GetBadgeById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.ProductBadges.AsNoTracking().Include(p => p.Product)
            .SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<ProductBadge, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.ProductBadges.AsNoTracking().AnyAsync(predicate, cancellationToken);
    }

    public async Task<bool> ExistsWithIgnoreQueryFilterAsync(Expression<Func<ProductBadge, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.ProductBadges.IgnoreQueryFilters().AsNoTracking().AnyAsync(predicate, cancellationToken);
    }
}