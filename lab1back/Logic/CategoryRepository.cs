using lab1back.Models;

namespace lab1back.Logic;

public class CategoryRepository : BaseStorage, ICategoryRepository
{
    public void DeleteCategory(Guid id)
    {
        var category = GetCategoryById(id);
        if (category is null)
            return;

        _category.Remove(category);
    }

    public void AddCategory(Category category)
    {
        var existCategory = GetCategoryById(category.Id);
        if (existCategory is not null)
            return;

        _category.Add(category);
    }

    public Category GetCategoryById(Guid id)
        => _category.FirstOrDefault(i => i.Id == id);

}