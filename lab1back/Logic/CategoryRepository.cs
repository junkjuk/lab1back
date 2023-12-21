using DB;
using Entities;
using lab1back.Models;
using AppContext = DB.AppContext;

namespace lab1back.Logic;

public class CategoryRepository : ICategoryRepository
{
    private readonly Repositories _repositories;

    public CategoryRepository(Repositories repositories)
    {
        _repositories = repositories;
    }

    public Task DeleteCategory(Guid id)
        => _repositories.CategoryRepository.DeleteByIdAsync(id);
    

    public Task AddCategory(Category category)
        => _repositories.CategoryRepository.AddAsync(category);

    public Task<Category> GetCategoryById(Guid id)
        => _repositories.CategoryRepository.GetByIdAsync(id);

}