using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary>
/// Represents a product variant (combination of color + size + stock + optional price override).
/// </summary>
public class ProductVariant : Entity<Guid>
{
    /// <summary>The overridden price for this variant, if exists.</summary>
    public decimal? PriceOverride { get; private set; }

    /// <summary>Available stock for this variant.</summary>
    public int Stock { get; private set; }

    /// <summary>Foreign key to the productVariant.</summary>
    public Guid ProductId { get; private set; }
    
    /// <summary>Navigation property to products in this productVariant.</summary>
    public Product Product { get; private set; } = null!;

    /// <summary>Foreign key to the productVariant.</summary>
    public Guid ColorId { get; private set; }
    
    /// <summary>Navigation property to Color in this productVariant.</summary>
    public Color Color { get; private set; } = null!;

    /// <summary>Foreign key to the productVariant.</summary>
    public Guid SizeId { get; private set; }
    
    /// <summary>Navigation Size to products in this productVariant.</summary>
    public Size Size { get; private set; } = null!;

    private ProductVariant() { }

    #region Constructor | Create

    /// <summary>Create a product variant and mark it as Created.</summary>
    /// <param name="productId">Related product ID.</param>
    /// <param name="colorId">Variant color ID.</param>
    /// <param name="sizeId">Variant size ID.</param>
    /// <param name="stock">Initial stock.</param>
    /// <param name="priceOverride">Optional price override.</param>
    /// <param name="createdBy">Admin who created the variant.</param>
    public ProductVariant( Guid productId, Guid colorId, Guid sizeId, int stock, decimal? priceOverride = null, string? createdBy = null)
    {
        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative.", nameof(stock));

        Id = Guid.NewGuid();

        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        Stock = stock;
        PriceOverride = priceOverride;

        MarkCreated(createdBy);
    }

    #endregion

    #region Helper Methods : Update, Delete, Restore

    /// <summary>Update variant stock or price and mark it as Modified.</summary>
    /// <param name="stock">New stock value.</param>
    /// <param name="priceOverride">New price override.</param>
    /// <param name="modifiedBy">Admin who modified the variant.</param>
    public void Update( int stock, decimal? priceOverride = null, string? modifiedBy = null)
    {
        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative.", nameof(stock));

        Stock = stock;
        PriceOverride = priceOverride;

        MarkModified(modifiedBy);
    }

    /// <summary>Reduce stock quantity (for orders).</summary>
    /// <param name="quantity">Quantity to subtract.</param>
    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive.");

        if (quantity > Stock)
            throw new InvalidOperationException("Not enough stock available.");

        Stock -= quantity;
    }

    /// <summary>Soft delete the variant and mark it as Deleted.</summary>
    /// <param name="deletedBy">Admin who deleted this variant.</param>
    public void Delete(string? deletedBy = null)
    {
        MarkDeleted(deletedBy);
    }

    /// <summary>Restore a softly deleted variant and mark it as Restored.</summary>
    /// <param name="restoredBy">Admin who restored this variant.</param>
    public void Restore(string? restoredBy = null)
    {
        MarkRestored(restoredBy);
    }

    #endregion
}
