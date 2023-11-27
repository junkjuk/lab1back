using lab1back.Models;

namespace lab1back.Logic;

public interface IRecordRepository
{
    void DeleteRecord(Guid id);
    void AddRecord(Record category);
    Record GetRecordById(Guid id);
    IEnumerable<Record> GetRecords(RecordRequest request);
}