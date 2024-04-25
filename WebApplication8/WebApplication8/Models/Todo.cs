namespace WebApplication8.Models;

using System.ComponentModel.DataAnnotations;

public class Todo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}