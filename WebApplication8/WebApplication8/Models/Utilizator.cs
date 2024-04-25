using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models;
public class Utilizator
{
    
    [Key]
    public int UtilizatorId { get; set; }
    public string NumeUtilizator { get; set; }
    public string Parola { get; set; }
    public string Rol { get; set; }
}