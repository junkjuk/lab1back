using lab1back.Models;

namespace lab1back.Logic;

public interface IRecordRepository
{
    void DeleteRecord(Guid id);
    void AddRecord(Category category);
    Category GetRecordById(Guid id);
}