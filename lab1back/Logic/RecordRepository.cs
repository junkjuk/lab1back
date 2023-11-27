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

    public IEnumerable<Record> GetRecords(RecordRequest request)
    {
        if (request.category_id is null)
            return _record.Where(i => i.UserId == request.user_id);
        if (request.user_id is null)
            return _record.Where(i => i.CategoryId == request.category_id);
        return _record.Where(i => i.CategoryId == request.category_id)
            .Where(i => i.UserId == request.user_id);
    }
}