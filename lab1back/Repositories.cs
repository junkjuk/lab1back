using Entities;
using lab1back.Models;

namespace DB;

public class Repositories
{
    private readonly AppContext _context;

    public Repository<User> UserRepository { get; }
    public Repository<Bill> BillRepositor { get; } 
    public Repository<Record> RecordRepository { get; }
    public Repository<Category> CategoryRepository { get; }

    public Repositories(AppContext context)
    {
        _context = context;
        UserRepository = new Repository<User>(context);
        BillRepositor = new Repository<Bill>(context);
        RecordRepository = new Repository<Record>(context);
        CategoryRepository = new Repository<Category>(context);
    }
    
    public Task SaveAsync() => _context.SaveChangesAsync();
}