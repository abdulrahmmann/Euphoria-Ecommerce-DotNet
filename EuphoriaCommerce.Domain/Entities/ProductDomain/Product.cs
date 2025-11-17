using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.Entities.ReviewDomain;
using EuphoriaCommerce.Domain.Entities.WishlistDomain;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary> Represents a product. </summary>
public class Product : Entity<Guid>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int TotalStock { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public Guid SubCategoryId { get; private set; }
    public SubCategory SubCategory { get; private set; } = null!;

    public Guid BrandId { get; private set; }
    public Brand Brand { get; private set; } = null!;

    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
    public ICollection<Feedback> Feedbacks { get; private set; } = new List<Feedback>();
    public ICollection<Wishlist> Wishlists { get; private set; } = new List<Wishlist>();
    public ICollection<ProductImage> ProductImages { get; private set; } = new List<ProductImage>();
    public ICollection<ProductBadge> Badges { get; private set; } = new List<ProductBadge>();
    public ICollection<ProductTag> Tags { get; private set; } = new List<ProductTag>();

    private Product() { }

    public Product(string name, string description, decimal price, int totalStock, Guid categoryId, Guid subCategoryId, Guid brandId)
    {
        if (price <= 0) throw new ArgumentException("Price must be >= 0", nameof(price));
        
        Id = Guid.NewGuid();
        
        Name = name;
        Description = description;
        Price = price;
        TotalStock = totalStock;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        BrandId = brandId;
    }
}