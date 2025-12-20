using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Question
    {
        public int Id { get; set; }

        // Question text
        [Required]
        public string Texte { get; set; } = string.Empty;

        // Question category/type
        public string Type { get; set; } = string.Empty;

        // Default points
        public int Points { get; set; } = 1;

        // Foreign key → Evaluation
        public int EvaluationId { get; set; }
        public virtual Evaluation Evaluation { get; set; }

        // List of options
        public virtual ICollection<OptionReponse> Options { get; set; }
            = new List<OptionReponse>();

        // Candidate responses
        public virtual ICollection<ReponseCandidat> ReponsesCandidats { get; set; }
            = new List<ReponseCandidat>();
    }
}
