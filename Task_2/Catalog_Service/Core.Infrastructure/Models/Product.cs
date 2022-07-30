using System.ComponentModel.DataAnnotations;

namespace Core.Infrastructure.Models;

public class Product
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Range(1, int.MaxValue)]
    public int Amount { get; set; }

    public virtual Category Category { get; set; } = new Category();
}
