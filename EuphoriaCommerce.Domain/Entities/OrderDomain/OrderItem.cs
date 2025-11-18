namespace EuphoriaCommerce.Domain.Entities.OrderDomain;

public class OrderItem
{
    public Guid ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public decimal SubTotal => Price * Quantity;
    
    private OrderItem() { } 

    public OrderItem(Guid productId, decimal price, int quantity)
    {
        if (price <= 0) throw new ArgumentException("Invalid price");
        if (quantity <= 0) throw new ArgumentException("Invalid quantity");
        
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}