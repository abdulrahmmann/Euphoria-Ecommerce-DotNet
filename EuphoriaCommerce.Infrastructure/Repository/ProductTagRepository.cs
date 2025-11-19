using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductTagRepository(ApplicationDbContext dbContext): IProductTagRepository
{
    public async Task<List<ProductTag>> GetTags(CancellationToken cancellationToken)
    {
        return await dbContext.ProductTags.ToListAsync(cancellationToken);
    }

    public async Task AddBrand(ProductTag tag, CancellationToken cancellationToken)
    {
        var tagToAdd = await dbContext.ProductTags.FirstOrDefaultAsync(c => c.Name == tag.Name, cancellationToken);
        
        if (tagToAdd != null) return;
        
        await dbContext.ProductTags.AddAsync(tagToAdd!, cancellationToken);
    }
}