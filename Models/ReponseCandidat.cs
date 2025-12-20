// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace ProjetEvaluationEnLigne.Models
// {
//     public class ReponseCandidat
//     {
//         public int Id { get; set; }

//         public string ReponseTexte { get; set; }

//         // Relations
//         [ForeignKey("Question")]
//         public int QuestionId { get; set; }
//         public virtual Question Question { get; set; }

//         [ForeignKey("Tentative")]
//         public int TentativeId { get; set; }
//         public virtual Tentative Tentative { get; set; }

//         [ForeignKey("OptionReponse")]
//         public int? OptionReponseId { get; set; }
//         public virtual OptionReponse OptionReponse { get; set; }
//     }
// }
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ReponseCandidat
    {
        public int Id { get; set; }

        public string ReponseTexte { get; set; } = string.Empty;

        // Relations
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }

        [ForeignKey("Tentative")]
        public int TentativeId { get; set; }
        public virtual Tentative? Tentative { get; set; }

        [ForeignKey("OptionReponse")]
        public int? OptionReponseId { get; set; }
        public virtual OptionReponse? OptionReponse { get; set; }
    }
}