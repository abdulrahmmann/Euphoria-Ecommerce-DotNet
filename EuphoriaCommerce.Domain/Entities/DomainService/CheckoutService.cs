using EuphoriaCommerce.Domain.Entities.CartDomain;
using EuphoriaCommerce.Domain.Entities.OrderDomain;

namespace EuphoriaCommerce.Domain.Entities.DomainService;

public class CheckoutService
{
    public static Order CreateOrderFromCart(Cart cart)
    {
        if (cart.CartItems.Count == 0) throw new ArgumentException("Cart is empty.");

        var order = new Order(cart.UserId);

        foreach (var item in cart.CartItems)
        {
            order.AddItem(item.ProductId, item.Price, item.Quantity);
        }

        return order;
    }
}