// using WebApplication1.Models;
// using System;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace ProjetEvaluationEnLigne.Models
// {
//     public class Candidature
//     {
//         public int Id { get; set; }

//         [Required]
//         public string Statut { get; set; }

//         public DateTime DateCandidature { get; set; }

//         // Relation avec Candidat
//         [ForeignKey("Candidat")]
//         public int CandidatId { get; set; }
//         public virtual Candidat Candidat { get; set; }
//     }
// }
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Candidature
    {
        public int Id { get; set; }

        [Required]
        public string Statut { get; set; } = string.Empty;

        public DateTime DateCandidature { get; set; }

        // Relation avec Candidat
        [ForeignKey("Candidat")]
        public int CandidatId { get; set; }
        public virtual Candidat? Candidat { get; set; }
    }
}