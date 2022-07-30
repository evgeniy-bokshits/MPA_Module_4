using Core.Infrastructure.Models;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }


    public async Task<Category> AddCategory(Category category)
    {
        return await _categoryRepository.AddCategory(category);
    }

    public async Task DeleteCategory(int id)
    {
        await _productRepository.DeleteProductsByCategory(id);
        await _categoryRepository.DeleteCategory(id);
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryRepository.GetAllCategories();
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        return await _categoryRepository.UpdateCategory(category);
    }
}
