using lab1back.Models;

namespace lab1back.Logic;

public class RecordRepository : BaseStorage, IRecordRepository
{
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
}