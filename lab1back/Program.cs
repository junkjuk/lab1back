using DB;
using lab1back.Logic;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("WebApiDatabase")!;

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IRecordRepository, RecordRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<Repositories>();
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