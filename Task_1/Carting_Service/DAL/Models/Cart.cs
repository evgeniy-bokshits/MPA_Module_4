using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Cart
{
    [Required]
    public string Id { get; set; }
    public IList<Item> Items { get; set; } = new List<Item>();
}
