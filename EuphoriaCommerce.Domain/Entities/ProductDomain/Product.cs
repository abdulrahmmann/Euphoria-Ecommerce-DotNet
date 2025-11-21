using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;
using EuphoriaCommerce.Domain.Entities.ReviewDomain;
using EuphoriaCommerce.Domain.Entities.WishlistDomain;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary> Represents a product. </summary>
public class Product : Entity<Guid>
{
    /// <summary>The product name.</summary>
    public string Name { get; private set; } = null!;

    /// <summary>The product description.</summary>
    public string Description { get; private set; } = null!;

    /// <summary>The base price of the product.</summary>
    public decimal Price { get; private set; }

    /// <summary>Total stock for the product (sum of all variants).</summary>
    public int TotalStock { get; private set; }

    /// <summary>Category ID Foreign key this product belongs to.</summary>
    public Guid CategoryId { get; private set; }

    /// <summary>Navigation property for Category.</summary>
    public Category Category { get; private set; } = null!;

    /// <summary>Sub-category Foreign key this product belongs to.</summary>
    public Guid GenderCategoryId { get; private set; }

    /// <summary>Navigation to GenderCategory.</summary>
    public GenderCategory GenderCategory { get; private set; } = null!;

    /// <summary>Brand ID Foreign key this product belongs to.</summary>
    public Guid BrandId { get; private set; }

    /// <summary>Navigation to Brand.</summary>
    public Brand Brand { get; private set; } = null!;

    /// <summary>Product variants (color, size, stock).</summary>
    public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();

    /// <summary>User feedbacks related to this product.</summary>
    public ICollection<Feedback> Feedbacks { get; private set; } = new List<Feedback>();

    /// <summary>Wishlists that include this product.</summary>
    public ICollection<Wishlist> Wishlists { get; private set; } = new List<Wishlist>();

    /// <summary>List of images for the product.</summary>
    public ICollection<ProductImage> ProductImages { get; private set; } = new List<ProductImage>();

    /// <summary>Badges displayed near the product.</summary>
    public ICollection<ProductBadge> Badges { get; private set; } = new List<ProductBadge>();

    /// <summary>Product tags used for searching and filtering.</summary>
    public ICollection<ProductTag> Tags { get; private set; } = new List<ProductTag>();
    
    private Product() { }

    #region Constructor | Create
    /// <summary>Create a new product and mark it as Created. </summary>
    public Product(string name, string description, decimal price, int totalStock, Guid categoryId, Guid genderCategory,
        Guid brandId, string? createdBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        if (price < 0)
            throw new ArgumentException("Price must be non-negative.", nameof(price));

        if (totalStock < 0)
            throw new ArgumentException("Stock cannot be negative.", nameof(totalStock));

        Id = Guid.NewGuid();

        Name = name;
        Description = description;
        Price = price;
        TotalStock = totalStock;

        CategoryId = categoryId;
        GenderCategoryId = genderCategory;
        BrandId = brandId;

        MarkCreated(createdBy);
    }

    #endregion
    
    #region Helper Methods : Update, Delete, Restore
    public static Product Create(string name, string description, decimal price, int totalStock, Guid categoryId, Guid subCategoryId, Guid brandId, string? createdBy = "System")
    {
        var product = new Product(name, description, price, totalStock, categoryId, subCategoryId, brandId, createdBy)
        {
            CreatedAt = DateTime.UtcNow
        };
        return product;
    }
    
    /// <summary>Update product basic information.</summary>
    public void Update(string? name, string? description, decimal? price, int? totalStock, Guid? categoryId, Guid? genderCategoryId, Guid? brandId, string? modifiedBy = "System")
    {
        Name = name ?? Name;
        Description = description ?? Description;
        Price = price ?? Price;
        TotalStock = totalStock ?? TotalStock;
        CategoryId = categoryId ?? CategoryId;
        GenderCategoryId = genderCategoryId ?? GenderCategoryId;
        BrandId = brandId ?? BrandId;

        MarkModified(modifiedBy);
    }
    
    public void Update( string name, string description, decimal price, string? modifiedBy = "System")
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        if (price < 0)
            throw new ArgumentException("Price must be non-negative.", nameof(price));

        Name = name;
        Description = description;
        Price = price;

        MarkModified(modifiedBy);
    }

    /// <summary>Update the product category or brand.</summary>
    public void UpdateCategoryBrand( Guid categoryId, Guid genderCategoryId, Guid brandId, string? modifiedBy = "System")
    {
        CategoryId = categoryId;
        GenderCategoryId = genderCategoryId;
        BrandId = brandId;

        MarkModified(modifiedBy);
    }

    /// <summary>Soft delete the product.</summary>
    public void Delete(string? deletedBy = "System")
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a deleted product.</summary>
    public void Restore(string? restoredBy = "System")
    {
        MarkRestored(restoredBy);
    }
    #endregion

    #region Helper Methods : Stock, Variants, Tags, Images, Badges
    /// <summary>Add stock to the product.</summary>
    public void IncreaseStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        TotalStock += amount;
    }

    /// <summary>Reduce stock from the product.</summary>
    public void ReduceStock(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.");

        if (amount > TotalStock)
            throw new InvalidOperationException("Not enough stock available.");

        TotalStock -= amount;
    }

    /// <summary>Add a product variant.</summary>
    public void AddVariant(ProductVariant variant)
    {
        Variants.Add(variant);
        TotalStock += variant.Stock;
    }

    /// <summary>Add an image to the product.</summary>
    public void AddImage(ProductImage image)
    {
        ProductImages.Add(image);
    }

    /// <summary>Add a tag to the product.</summary>
    public void AddTag(ProductTag tag)
    {
        Tags.Add(tag);
    }

    /// <summary>Add a badge to the product.</summary>
    public void AddBadge(ProductBadge badge)
    {
        Badges.Add(badge);
    }
    #endregion
}
