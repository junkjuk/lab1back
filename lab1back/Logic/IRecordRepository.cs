using Entities;
using lab1back.Models;

namespace lab1back.Logic;

public interface IRecordRepository
{
    Task DeleteRecord(Guid id);
    Task AddRecord(Record category);
    Task<Record> GetRecordById(Guid id);
    Task<IEnumerable<Record>> GetRecords(RecordRequest request);
}