using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models;

public class FilterModel
{
    [Required]
    public int CategoryId { get; set; }
    public int Skip { get; set; }
    public int Count { get; set; } = 10;
}
