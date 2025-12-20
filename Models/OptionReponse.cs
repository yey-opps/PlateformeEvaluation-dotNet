using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OptionReponse
    {
        public int Id { get; set; }
        
        [Required]
        public bool EstCorrecte { get; set; }   // NOT EstCorrect

        
        
        // Relation avec Question
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }
        
        // Relation avec ReponseCandidat
        public virtual ICollection<ReponseCandidat> ReponsesCandidats { get; set; } = new List<ReponseCandidat>();
        public string Texte { get; set; }
    }
}