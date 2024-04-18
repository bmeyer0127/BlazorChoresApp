using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
  public static string[] CompletionStatusOptions = { "Not Completed", "Completed" };

  [Required]
  public int PersonId { get; set; }

  public Person? Person { get; set; }
}