using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Persistence;

namespace DAL.Implementations;

public class CartRepository : ICartRepository
{
    private readonly ICartingDbContext _cartingDbContext;
    private readonly IMapper _mapper;

    public CartRepository(ICartingDbContext cartingDbContext, IMapper mapper)
    {
        _cartingDbContext = cartingDbContext;
        _mapper = mapper;
    }

    public void AddCartItem(string id, Models.Item item)
    {
        var item1 = _mapper.Map<Persistence.Models.Item>(item);
        _cartingDbContext.AddCartItem(id, item1);
    }

    public IEnumerable<Models.Item> GetCartItems(string id)
    {
        var items = _cartingDbContext.GetCartItems(id);
        var itemsToReturn = _mapper.Map<List<Models.Item>>(items);
        return itemsToReturn;
    }

    public void RemoveCartItem(string id, Models.Item item)
    {
        var item1 = _mapper.Map<Persistence.Models.Item>(item);
        _cartingDbContext.RemoveCartItem(id, item1);
    }

    public Cart GetCart(string id)
    {
        var cart = _cartingDbContext.GetCart(id);
        return _mapper.Map<DAL.Models.Cart>(cart);
    }

    public void AddCart(Cart cart)
    {
        var cartDomain = _mapper.Map<Persistence.Models.Cart>(cart);
        _cartingDbContext.AddCart(cartDomain);
    }
}
