using DB;
using lab1back.Logic;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("WebApiDatabase")!;
// var optionsBuilder = new DbContextOptionsBuilder<DB.AppContext>()
    // .UseNpgsql(connection, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());

// var repos = new Repositories(new DB.AppContext(optionsBuilder.Options));

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IRecordRepository, RecordRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddDbContext<DB.AppContext>(i =>
{
    i.UseNpgsql(connection, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();