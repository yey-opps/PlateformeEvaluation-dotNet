using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Entretien
    {
        public int Id { get; set; }

        [Required]
        public int CandidatId { get; set; }

        [ForeignKey("CandidatId")]
        public virtual Candidat? Candidat { get; set; }

        [Required]
        public DateTime DateEntretien { get; set; }

        [Required]
        public string Statut { get; set; } = "Programmé"; // "Programmé", "Terminé", "Annulé"

        public string? TypeEntretien { get; set; } // "Technique", "RH", "Final"

        public string? Lieu { get; set; } // "Bureau", "Visio", "Téléphone"

        public string? Commentaire { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public string? ResultatFinal { get; set; } // "Embauché", "Rejeté", "En attente"
    }
}