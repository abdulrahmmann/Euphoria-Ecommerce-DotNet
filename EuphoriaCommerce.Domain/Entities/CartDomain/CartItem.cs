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
    public void IncreaseQuantity(int value)
    {
        if (value <= 0) throw new ArgumentException("Increase must be > 0");
        
        Quantity += value;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantity Invalid");

        Quantity = quantity;
    }
}