using Core.Infrastructure.Models;

namespace DAL.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetCategory(int id);
    Task<List<Category>> GetAllCategories();
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task DeleteCategory(int id);
}
