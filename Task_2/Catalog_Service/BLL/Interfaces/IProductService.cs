using Core.Infrastructure.Models;

namespace BLL.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts(int categoryId, int skip, int count);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int productId);
}
