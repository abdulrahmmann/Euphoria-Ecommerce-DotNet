using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductImageRepository(ApplicationDbContext dbContext): IProductImageRepository
{
    public async Task<List<ProductImage>> GetProductImages(CancellationToken cancellationToken)
    {
        return await dbContext.ProductImages.ToListAsync(cancellationToken);
    }

    public async Task AddProductImage(ProductImage productImage, CancellationToken cancellationToken)
    {
        var imageToAdd = await dbContext.ProductImages.FirstOrDefaultAsync(c => c.ImageUrl == productImage.ImageUrl, cancellationToken);
        
        if (imageToAdd != null) return;
        
        await dbContext.ProductImages.AddAsync(imageToAdd!, cancellationToken);
    }
}