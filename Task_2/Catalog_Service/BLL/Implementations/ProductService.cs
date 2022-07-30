using Core.Infrastructure.Models;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Implementations;

public class ProductService : IProductService
{
    const int Skip = 0;
    const int Count = 10;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<Product> AddProduct(Product product)
    {
        return await _productRepository.AddProduct(product);
    }

    public async Task DeleteProduct(int productId)
    {
        await _productRepository.DeleteProduct(productId);
    }

    public async Task<IEnumerable<Product>> GetProducts(int categoryId, int skip = Skip, int count = Count)
    {
        return await _productRepository.GetProducts(categoryId, skip, count);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        return await _productRepository.UpdateProduct(product);
    }
}
