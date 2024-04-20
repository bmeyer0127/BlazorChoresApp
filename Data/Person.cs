using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Person
{
  [Key]
  public int PersonId { get; set; }

  [Required]
  public string? Name { get; set; }
}