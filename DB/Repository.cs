using Entities;
using lab1back.Models;
using Microsoft.EntityFrameworkCore;

namespace DB;

public class Repository<T> where T : EntityId
{
    public readonly AppContext Context;

    public Repository(AppContext context)
    {
        Context = context;
    }
    
    public async Task<T> GetByIdAsync(Guid id)
        => await Context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    

    public async Task<T> UpdateAsync(T entity)
    {
        var entityToUpdate = await Context.Set<T>().FirstAsync(x => x.Id.Equals(entity.Id));
        entityToUpdate = entity;
        await SaveAsync();
        return entityToUpdate;
    }

    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await SaveAsync();
    }
    

    public async Task<T> DeleteByIdAsync(Guid id)
    {
        var model = await GetByIdAsync(id);
        Context.Set<T>().Remove(model);
        await SaveAsync();
        return model;
    }

    public Task<List<T>> GetAllAsync()
        => Context.Set<T>().ToListAsync();
    
    public Task SaveAsync()
        => Context.SaveChangesAsync();
    
}