using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.ProductDomain;

/// <summary> Represent a Product Images. </summary>
public class ProductImage: Entity<Guid>
{
    public string ImageUrl { get; private set; } = null!;
    public bool IsMain { get; private set; } = false;
    
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    private ProductImage() { }

    public ProductImage(string imageUrl, bool isMain, Guid productId)
    {
        Id = Guid.NewGuid();
        
        ImageUrl = imageUrl;
        IsMain = isMain;
        ProductId = productId;
    }
}