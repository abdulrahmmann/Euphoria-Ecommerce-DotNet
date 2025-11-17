using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.WishlistDomain;

/// <summary> Represents a user's wishlist item. </summary>
public class Wishlist : Entity<Guid>
{
    public Guid UserId { get; private set; }
    public Guid ProductId { get; private set; }
    
    public Product? Product { get; private set; } = null!;

    private Wishlist() { }

    private Wishlist(Guid userId, Guid productId)
    {
        Id = Guid.NewGuid();
        
        UserId = userId;
        ProductId = productId;
    }
}