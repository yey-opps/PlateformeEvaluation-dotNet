using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        
        [Required]
        public string Titre { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public int DureeMinutes { get; set; }
        
        public DateTime DateCreation { get; set; }
        
        // Relations
        public virtual ICollection<Tentative> Tentatives { get; set; } = new List<Tentative>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}