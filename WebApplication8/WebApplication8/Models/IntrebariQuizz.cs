using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models;

public class IntrebariQuizz
{

    [Key]
    public int IntrebareId { get; set; }
    public string TextIntrebare { get; set; }
    public string[] OptiuniRaspuns { get; set; }
    public int RaspunsCorect { get; set; }
}