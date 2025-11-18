using EuphoriaCommerce.Domain.Bases;

namespace EuphoriaCommerce.Domain.Entities.CartDomain;

public class Cart: Entity<Guid>
{
    public Guid UserId { get; private set; }
    
    private readonly List<CartItem> _cartItems = new();
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();
    
    public decimal TotalPrice => _cartItems.Sum(i => i.SubTotal);
    
    private Cart() {}

    public Cart(Guid userId, string? createdBy = null)
    {
        Id = Guid.NewGuid();
        
        UserId = userId;
        MarkCreated(createdBy);
    }
    public void AddItem(Guid productId,  int quantity, decimal price)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be > 0");
        
        var existing = _cartItems.FirstOrDefault(c => c.ProductId == productId);
        
        if (existing is not null) existing.IncreaseQuantity(quantity);
        
        else _cartItems.Add(new CartItem(productId, price, quantity));
    }
    
    public void UpdateQuantity(Guid productId, int quantity)
    {
        var item = _cartItems.FirstOrDefault(i => i.ProductId == productId) ?? throw new ArgumentException("Item not found");

        item.SetQuantity(quantity);

        if (item.Quantity == 0)
            _cartItems.Remove(item);
    }

    public void RemoveItem(Guid productId)
    {
        var item = _cartItems.FirstOrDefault(i => i.ProductId == productId) ?? throw new ArgumentException("Item not found");

        _cartItems.Remove(item);
    }

    public void Clear()
    {
        _cartItems.Clear();
    }
    
}