using DAL.Models;

namespace BLL.Interfaces;

public interface ICartService
{
    Cart GetCartInfo(string key);
    void AddItemToCart(string id, Item item);
    void DeleteItemFromCart(string id, Item item);
}
