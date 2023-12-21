using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DB;

public class AppContextFactory: IDesignTimeDbContextFactory<AppContext>
{
    public AppContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppContext>();
        var connectionString = "";
        builder.UseNpgsql(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        return new AppContext(builder.Options);
    }
}