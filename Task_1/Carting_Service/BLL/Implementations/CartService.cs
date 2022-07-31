using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Newtonsoft.Json;

namespace BLL.Implementations;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public void AddItemToCart(string id, Item item)
    {
        var cart = _cartRepository.GetCart(id);

        if (cart is null)
        {
            cart = new Cart();
        }

        cart.Items.Add(item);
        _cartRepository.AddCartItem(id, item);
    }
    public void DeleteItemFromCart(string id, Item item)
    {
        _cartRepository.RemoveCartItem(id, item);
    }
    public Cart GetCartInfo(string id)
    {
        return _cartRepository.GetCart(id);
    }

    public void UpdateCartItems(string message)
    {
        var item = JsonConvert.DeserializeObject<Item>(message);

        if (item is not null)
        {
            // update cart's items. Now it's difficult to write code because we use LiteDb
        }
    }
}
