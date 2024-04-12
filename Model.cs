using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ChoresContext : DbContext
{
  public DbSet<Chore> Chores { get; set; }
  public DbSet<Person> Persons { get; set; }

  public string DbPath { get; }

  public ChoresContext()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = System.IO.Path.Join(path, "ChoreInfo.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
}

public class Chore
{
  public int ChoreId { get; set; }

  [Required]
  [Display(Name = "Chore")]
  public string? ChoreName { get; set; }

  [Display(Name = "Chore Description")]
  public string? ChoreDescription { get; set; }

  [Required]
  [Display(Name = "Completion Status")]
  public string? CompletionStatus { get; set; }
  public static string[]? CompletionStatusOptions = { "Not Completed", "Completed" };

  [Required]
  public int PersonId { get; set; }

  public Person? Person { get; set; }
}

public class Person
{
  public int PersonId { get; set; }

  [Required]
  public string? Name { get; set; }

  public List<Chore> Chores { get; } = new List<Chore>();
}