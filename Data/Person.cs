using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Person
{
  public int PersonId { get; set; }

  [Required]
  public string? Name { get; set; }

  public List<Chore> Chores { get; } = new List<Chore>();
}