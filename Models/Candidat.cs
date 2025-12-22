using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Candidat
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = string.Empty;

        public string Prenom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? UserId { get; set; } // Pour lier avec Identity

        public string Statut { get; set; } = "CV en attente";
        // Statuts possibles :
        // "CV en attente" → "Éligible aux tests" → "Tests en cours" → "Tests terminés" 
        // → "Réussi aux tests" / "Échec aux tests" → "Entretien programmé" → "Embauché" / "Rejeté"

        public double? ScoreGlobal { get; set; }

        public int? Note { get; set; } // Note sur 5 étoiles (pour l'UI)

        // Relations
        public virtual ICollection<Tentative> Tentatives { get; set; } = new List<Tentative>();
        public virtual ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();
    }
}