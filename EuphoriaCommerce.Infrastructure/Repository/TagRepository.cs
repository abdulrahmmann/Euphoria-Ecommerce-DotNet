using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class TagRepository(ApplicationDbContext dbContext): ITagRepository
{
    public async Task<List<ProductTag>> GetTags(CancellationToken cancellationToken)
    {
        return await dbContext.ProductTags.ToListAsync(cancellationToken);
    }

    public async Task AddTag(ProductTag tag, CancellationToken cancellationToken)
    {
        var tagToAdd = await dbContext.ProductTags.FirstOrDefaultAsync(c => c.Name == tag.Name, cancellationToken);
        
        if (tagToAdd != null) return;
        
        await dbContext.ProductTags.AddAsync(tagToAdd!, cancellationToken);
    }

    public async Task<ProductTag?> GetTagById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.ProductTags.SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<ProductTag, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.ProductTags.AsNoTracking().AnyAsync(predicate, cancellationToken);
    }

    public async Task<bool> ExistsWithIgnoreQueryFilterAsync(Expression<Func<ProductTag, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.ProductTags.IgnoreQueryFilters().AsNoTracking().AnyAsync(predicate, cancellationToken);
    }
}