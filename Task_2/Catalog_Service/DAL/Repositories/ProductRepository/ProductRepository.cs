using Microsoft.EntityFrameworkCore;

using DAL.DBContexts.CatalogDBContext;
using DAL.Interfaces;
using Core.Infrastructure.Models;

namespace DAL.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Product>> GetProducts(int categoryId, int skip, int count)
    {
        return await _dbContext.Products
            .Where(p => p.CategoryId == categoryId)
            .Skip(skip)
            .Take(count)
            .ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Product> UpdateProduct(Product category)
    {
        _dbContext.Update(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task DeleteProductsByCategory(int categoryId)
    {
        var products = await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        _dbContext.RemoveRange(products);
        await _dbContext.SaveChangesAsync();
    }
}
