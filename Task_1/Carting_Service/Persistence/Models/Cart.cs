namespace Persistence.Models;

public class Cart
{
    public string Id { get; set; }
    public IList<Item> Items { get; set; } = new List<Item>();
}
