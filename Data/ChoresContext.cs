using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

public class ChoresContext : DbContext
{

  public static readonly string ChoresDb = nameof(ChoresDb).ToLower();

  public ChoresContext(DbContextOptions<ChoresContext> options) : base(options)
  {
    Debug.WriteLine($"{ContextId} context created");
  }

  public DbSet<Chore>? Chores { get; set; }
  public DbSet<Person>? Persons { get; set; }
}