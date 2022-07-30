using DAL.Models;

namespace DAL.Interfaces;

public interface ICartRepository
{
    IEnumerable<Item> GetCartItems(string id);
    void AddCartItem(string id, Item item);
    void RemoveCartItem(string id, Item item);
    Cart GetCart(string id);
    void AddCart(Cart cart);
}
