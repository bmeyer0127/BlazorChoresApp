using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

public class Chore
{
  [Key]
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
  [ForeignKey("PersonId")]
  public int PersonId { get; set; }
  public virtual Person? Person { get; set; }
}