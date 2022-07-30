using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Item
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public Image Image { get; set; }
    [Required]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
