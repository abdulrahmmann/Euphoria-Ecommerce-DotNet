using EuphoriaCommerce.Domain.Bases;
using EuphoriaCommerce.Domain.Entities.CartDomain;

namespace EuphoriaCommerce.Domain.Entities.OrderDomain;

public class Order: Entity<Guid>
{
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
    
    public Guid UserId { get; private set; }
    public decimal TotalPrice => _orderItems.Sum(i => i.SubTotal);
    
    private Order() { } 

    public Order(Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
    }
    public void AddItem(Guid productId, decimal price, int quantity)
    {
        _orderItems.Add(new OrderItem(productId, price, quantity));
    }
}