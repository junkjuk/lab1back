using lab1back.Models;
using Microsoft.EntityFrameworkCore;

namespace DB;

public class AppContext : DbContext
{
    public DbSet<Record> Records { get; set; }        
    public DbSet<Category> Categorys { get; set; }        
    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }

    public AppContext(DbContextOptions<AppContext> options) 
        : base(options) 
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>().HasKey(a => a.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Records)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasOne<Bill>(u => u.Bill)
            .WithOne(r => r.User)
            .HasForeignKey<Bill>(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Record>()
            .HasOne(r => r.Category)
            .WithMany(c => c.Records)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Records)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}