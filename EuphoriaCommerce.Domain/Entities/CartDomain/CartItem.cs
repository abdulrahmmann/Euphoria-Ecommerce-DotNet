using EuphoriaCommerce.Domain.Entities.ProductDomain;

namespace EuphoriaCommerce.Domain.Entities.CartDomain;

public class CartItem
{
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal SubTotal => Price * Quantity;
    
    public Guid ProductId { get; private set; } 
    
    public Product Product { get; private set; } = null!;
    
    public CartItem(Guid productId, decimal price, int quantity)
    {
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}