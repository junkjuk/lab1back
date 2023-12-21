using DB;
using Entities;
using lab1back.Models;
using AppContext = DB.AppContext;

namespace lab1back.Logic;

public class RecordRepository : IRecordRepository
{
    private readonly Repositories _repositories;
    private readonly IBillService _billService;

    public RecordRepository(Repositories repositories, IBillService billService)
    {
        _repositories = repositories;
        _billService = billService;
    }

    public Task DeleteRecord(Guid id)
        => _repositories.RecordRepository.DeleteByIdAsync(id);

    public async Task AddRecord(Record category)
    {
        await _billService.MinusMoney(category.UserId, category.Amount);
        await _repositories.RecordRepository.AddAsync(category);
    }

    public Task<Record> GetRecordById(Guid id)
        => _repositories.RecordRepository.GetByIdAsync(id);

    public async Task<IEnumerable<Record>> GetRecords(RecordRequest request)
    {
        var result = await _repositories.RecordRepository.GetAllAsync();

        if (request.category_id is null)
            return result.Where(i => i.UserId == request.user_id);
        if (request.user_id is null)
            return result.Where(i => i.CategoryId == request.category_id);
        return result.Where(i => i.CategoryId == request.category_id)
            .Where(i => i.UserId == request.user_id);
    }
}