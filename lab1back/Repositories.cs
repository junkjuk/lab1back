using Entities;
using lab1back.Models;

namespace DB;

public class Repositories
{
    private readonly AppContext _context;

    public Repository<User> UserRepository { get; }
    public Repository<Bill> BillRepository { get; } 
    public Repository<Record> RecordRepository { get; }
    public Repository<Category> CategoryRepository { get; }

    public Repositories(AppContext context)
    {
        _context = context;
        UserRepository = new Repository<User>(context);
        BillRepository = new Repository<Bill>(context);
        RecordRepository = new Repository<Record>(context);
        CategoryRepository = new Repository<Category>(context);
    }
    
    public Task SaveAsync() => _context.SaveChangesAsync();
}