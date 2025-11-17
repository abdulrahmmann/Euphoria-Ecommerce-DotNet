using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.CartDomain;

public class Cart: Entity<Guid>
{
    public string UserId { get; private set; }
    public List<CartItem> CartItems { get; private set; } = new List<CartItem>();
    
    public decimal TotalPrice => CartItems.Sum(i => i.SubTotal);

    private Cart() {}

    public Cart(string userId)
    {
        Id = Guid.NewGuid();
        
        UserId = userId;
    }
}