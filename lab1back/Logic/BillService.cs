using DB;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace lab1back.Logic;

public class BillService : IBillService
{
    private readonly Repositories _repositories;

    public BillService(Repositories repositories)
    {
        _repositories = repositories;
    }

    public Task Add(Guid userId)
        => _repositories.BillRepository.AddAsync(new Bill
        {
            UserId = userId,
            Balance = 0
        });

    public Task<Bill> Get(Guid userId)
        => _repositories.BillRepository.Context.Set<Bill>().FirstOrDefaultAsync(x => x.UserId.Equals(userId));
    


    public async Task AddMoney(Guid userId, float amount)
    {
        var bill = await _repositories.BillRepository.Context.Set<Bill>().FirstOrDefaultAsync(x => x.UserId.Equals(userId));
        if (bill is null)
        {
            await Add(userId);
            bill = await _repositories.BillRepository.Context.Set<Bill>().FirstOrDefaultAsync(x => x.UserId.Equals(userId));
        }
        if (bill is null)
            return;
        bill.Balance += amount;
        BillValidator.ValidateBill(bill);
        await _repositories.BillRepository.UpdateAsync(bill);
    }

    public async Task MinusMoney(Guid userId, float amount)
    {
        var bill = await _repositories.BillRepository.Context.Set<Bill>().FirstOrDefaultAsync(x => x.UserId.Equals(userId));
        if (bill is null)
        {
            await Add(userId);
            bill = await _repositories.BillRepository.Context.Set<Bill>().FirstOrDefaultAsync(x => x.UserId.Equals(userId));
        }
        if (bill is null)
            return;
        bill.Balance -= amount;
        BillValidator.ValidateBill(bill);
        await _repositories.BillRepository.UpdateAsync(bill);
    }
}