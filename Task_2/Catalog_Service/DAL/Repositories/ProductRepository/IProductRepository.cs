using Core.Infrastructure.Models;

namespace DAL.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProduct(int id);
    Task<List<Product>> GetProducts(int categoryId, int skip, int count);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int id);
    Task DeleteProductsByCategory(int categoryId);
}
