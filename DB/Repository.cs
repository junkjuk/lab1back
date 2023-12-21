using lab1back.Models;
using Microsoft.EntityFrameworkCore;

namespace DB;

public class Repository<T> where T : EntityId
{
    private readonly AppContext Context;

    public Repository(AppContext context)
    {
        Context = context;
    }
    
    public async Task<T> GetByIdAsync(int id)
        => await Context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    

    public async Task<T> UpdateAsync(T entity)
    {
        var entityToUpdate = await Context.Set<T>().FirstAsync(x => x.Id.Equals(entity.Id));
        entityToUpdate = entity;
        return entityToUpdate;
    }

    public async Task AddAsync(T entity)
        => await Context.Set<T>().AddAsync(entity);
    

    public async Task<T> DeleteByIdAsync(int id)
    {
        var model = await GetByIdAsync(id);
        Context.Set<T>().Remove(model);
        return model;
    }

    public IAsyncEnumerable<T> GetAllAsync()
        => Context.Set<T>().AsAsyncEnumerable();
    
    public Task SaveAsync()
        => Context.SaveChangesAsync();
    
}