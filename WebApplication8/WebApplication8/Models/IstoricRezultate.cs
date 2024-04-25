using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class IstoricRezultate
    {
        [Key]
        public int Id { get; set; }

        public int UtilizatorId { get; set; }

        public int RezultatQuizzId { get; set; }

        public int Scor { get; set; }

        public DateTime DataRezultat { get; set; }

        
        // Relația cu entitățile Utilizator și RezultatQuizz
        public Utilizator Utilizator { get; set; }

        public IEnumerable<RezultatQuizz>? RezultatQuizz { get; set; }
    }
}