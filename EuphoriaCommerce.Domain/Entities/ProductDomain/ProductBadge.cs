using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary>
/// Represent a Product Badge.
/// </summary>
public class ProductBadge: Entity<Guid>
{
    public string Name { get; private set; } = null!;
    public string Color { get; private set; } = null!;

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    private ProductBadge() {}

    public ProductBadge(string name, string color, Guid productId)
    {
        Id = Guid.NewGuid();
        
        Name = name;
        Color = color;
        ProductId = productId;
    }
}