using Core.Infrastructure.Models;
using DAL.DBContexts.CatalogDBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly CatalogDbContext _dbContext;

    public CategoryRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> AddCategory(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category is null)
            throw new Exception("Category not found");

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _dbContext.Update(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }
}
