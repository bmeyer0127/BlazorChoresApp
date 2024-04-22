using BlazorChoresApp.Data;
using Microsoft.EntityFrameworkCore;

public static class DatabaseUtility
{
  // Method used to seed the database to provide sample data to debug with

  public static async Task DbIsCreatedAndSeededWithCountOfAsync(DbContextOptions<ChoresContext> options, int count)
  {
    var factory = new LoggerFactory();
    var builder = new DbContextOptionsBuilder<ChoresContext>(options).UseLoggerFactory(factory);

    using var context = new ChoresContext(builder.Options);

    if (await context.Database.EnsureCreatedAsync())
    {
      var seed = new SeedDb();
      await seed.SeedDatabase(context, count);
    }
  }
}