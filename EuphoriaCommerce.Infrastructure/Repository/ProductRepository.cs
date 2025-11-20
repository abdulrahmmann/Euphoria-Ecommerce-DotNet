using System.Linq.Expressions;
using EuphoriaCommerce.Domain.Entities.ProductDomain;
using EuphoriaCommerce.Domain.IRepository;
using EuphoriaCommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EuphoriaCommerce.Infrastructure.Repository;

public class ProductRepository(ApplicationDbContext dbContext): IProductRepository
{
    public IQueryable<Product?> GetProducts()
    {
        return dbContext.Products.AsNoTracking()
            .Include(c => c.Category)
            .Include(sc => sc.SubCategory)
            .Include(br => br.Brand)
            .OrderBy(product => product.Name)
            .ThenBy(product => product.Price)
            .AsSplitQuery();
    }
    
    public IQueryable<Product?> FilterProductsByCondition(Expression<Func<Product, bool>>  predicate)
    {
        return dbContext.Products
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(sc => sc.SubCategory)
            .Include(br => br.Brand)
            .AsSplitQuery()
            .Where(predicate)
            .OrderBy(product => product.Name)
            .ThenBy(product => product.Price);
    }
    public async Task AddProduct(Product product, CancellationToken cancellationToken, string? createdBy = "System")
    {
        var productToAdd = Product.Create(product.Name,  product.Description, product.Price, product.TotalStock, product.CategoryId, product.SubCategoryId, product.BrandId, createdBy);
        
        await dbContext.Products.AddAsync(productToAdd, cancellationToken);
    }
    
    public async Task UpdateProduct(Guid id, Product product, CancellationToken cancellationToken, string? modifiedBy = "product")
    {
        var productToUpdate = await dbContext.Products.SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);

        productToUpdate?.Update(product.Name, product.Description, product.Price, product.TotalStock, product.CategoryId, product.SubCategoryId, product.BrandId, modifiedBy);
    }

    public async Task DeleteProduct(Guid id, CancellationToken cancellationToken, string? deletedBy = null)
    {
        var productToDelete = await dbContext.Products.SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);

        productToDelete?.Delete(deletedBy);
    }

    public async Task RestoreProduct(Guid id, CancellationToken cancellationToken, string? restoredBy = null)
    {
        var productToRestore = await dbContext.Products.SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);

        productToRestore?.Restore(restoredBy);
    }

    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Products.SingleOrDefaultAsync(temp => temp.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await dbContext.Products.AsNoTracking().AnyAsync(predicate, cancellationToken);
    }
}