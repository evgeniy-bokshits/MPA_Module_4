using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
