using lab1back.Models;

namespace lab1back.Logic;

public interface ICategoryRepository
{
    void DeleteCategory(Guid id);
    void AddCategory(Category category);
    Category GetCategoryById(Guid id);
}