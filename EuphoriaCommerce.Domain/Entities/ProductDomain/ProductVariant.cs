using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.CatalogDomain;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary> Represents a product variant (color + size + stock). </summary>
public class ProductVariant : Entity<Guid>
{
    public decimal? PriceOverride { get; private set; }
    public int Stock { get; private set; }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    public Guid ColorId { get; private set; }
    public Color Color { get; private set; } = null!;

    public Guid SizeId { get; private set; }
    public Size Size { get; private set; } = null!;

    private ProductVariant() { }

    private ProductVariant(Guid productId, Guid colorId, Guid sizeId, int stock, decimal? priceOverride)
    {
        Id = Guid.NewGuid();
        
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        Stock = stock;
        PriceOverride = priceOverride;
    }
}