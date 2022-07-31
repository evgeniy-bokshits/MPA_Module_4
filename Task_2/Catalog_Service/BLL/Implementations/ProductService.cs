using Core.Infrastructure.Models;
using BLL.Interfaces;
using DAL.Interfaces;

using Newtonsoft.Json;

namespace BLL.Implementations;

public class ProductService : IProductService
{
    const int Skip = 0;
    const int Count = 10;
    private readonly IProductRepository _productRepository;
    private readonly IMessageService _messageService;

    public ProductService(IProductRepository productRepository, IMessageService messageService)
    {
        _productRepository = productRepository;
        _messageService = messageService;
    }

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
        var updatedProduct = await _productRepository.UpdateProduct(product);

        var message = JsonConvert.SerializeObject(updatedProduct);

        try
        {
            _messageService.Send(message);
        }
        catch
        {
            MessageService.UnsentMessages.Enqueue(message);
        }

        return updatedProduct;
    }
}