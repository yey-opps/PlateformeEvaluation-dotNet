using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Candidature
    {
        public int Id { get; set; }

        [Required]
        public string Statut { get; set; } = "En attente"; // "En attente", "Validé", "Rejeté"

        public DateTime DateCandidature { get; set; } = DateTime.Now;

        public string? CvPdfPath { get; set; } // Chemin du fichier PDF

        public bool EmailEnvoye { get; set; } = false;

        public DateTime? DateApprobation { get; set; }

        public string? CommentaireRejet { get; set; } // Optionnel : pourquoi rejeté

        // Relation avec Candidat
        [ForeignKey("Candidat")]
        public int CandidatId { get; set; }
        public virtual Candidat? Candidat { get; set; }
    }
}