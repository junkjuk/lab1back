using Entities;
using lab1back.Models;

namespace lab1back.Logic;

public interface ICategoryRepository
{
    Task DeleteCategory(Guid id);
    Task AddCategory(Category category);
    Task<Category> GetCategoryById(Guid id);
}