using Entities;

namespace lab1back.Logic;

public interface IBillService
{
    Task Add(Guid userId);
    Task<Bill> Get(Guid userId);
    Task AddMoney(Guid userId, float amount);
    Task MinusMoney(Guid userId, float amount);
}