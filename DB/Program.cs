// See https://aka.ms/new-console-template for more information

using DB;
using lab1back.Models;

var fack = new AppContextFactory();
var context = fack.CreateDbContext(new string[] { });

Console.WriteLine("start");
await context.Set<Category>().AddAsync(new Category {Id = Guid.NewGuid(), Name = "test2"});
await context.SaveChangesAsync();
foreach (var cat in context.Set<Category>())
{
    Console.WriteLine(cat.Name);
}
Console.WriteLine("end");