using lab1back.Models;

namespace lab1back.Logic;

public class GodRepository : ICategoryRepository, IRecordRepository, IUserRepository
{
    private List<Category> _category = new();
    private List<User> _user = new();
    private List<Record> _record = new();

    #region Category

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
    

    #endregion

    
    #region Record

    public void DeleteRecord(Guid id)
    {
        var existRecord = GetRecordById(id);
        if (existRecord is null)
            return;

        _record.Remove(existRecord);
    }

    public void AddRecord(Record category)
    {
        var existRecord = GetRecordById(category.Id);
        if (existRecord is not null)
            return;

        _record.Add(category);
    }

    public Record GetRecordById(Guid id)
        => _record.FirstOrDefault(i => i.Id == id);
    
    #endregion


    #region Users

    public void DeleteUser(Guid id)
    {
        var existUser = GetUserById(id);
        if (existUser is null)
            return;

        _user.Remove(existUser);
    }

    public void AddUser(User user)
    {
        var existUser = GetUserById(user.Id);
        if (existUser is not null)
            return;

        _user.Add(user);
    }

    public User GetUserById(Guid id)
        => _user.FirstOrDefault(i => i.Id == id);

    public IEnumerable<User> GetAllUsers()
        => _user;

    #endregion
}