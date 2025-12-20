// // using WebApplication1.Models;
// // using System;
// // using System.Collections.Generic;
// // using System.ComponentModel.DataAnnotations;
// // using System.ComponentModel.DataAnnotations.Schema;

// // namespace ProjetEvaluationEnLigne.Models
// // {
// //     public class Tentative
// //     {
// //         public int Id { get; set; }

// //         public DateTime DatePassage { get; set; }

// //         public float Score { get; set; }

// //         // Relation avec Candidat
// //         [ForeignKey("Candidat")]
// //         public int CandidatId { get; set; }
// //         public virtual Candidat Candidat { get; set; }

// //         // Relation avec Evaluation (nullable)
// //         public int? EvaluationId { get; set; }

// //         // Relation avec RéponseCandidat
// //         public virtual ICollection<ReponseCandidat> ReponsesCandidats { get; set; }
// //     }
// // }
// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace WebApplication1.Models
// {
//     public class Tentative
//     {
//         public int Id { get; set; }

//         public DateTime DatePassage { get; set; }

//         public float Score { get; set; }

//         // Relation avec Candidat
//         [ForeignKey("Candidat")]
//         public int CandidatId { get; set; }
//         public virtual Candidat? Candidat { get; set; }

//         // Relation avec Evaluation (nullable)
//         public int? EvaluationId { get; set; }
//         public virtual Evaluation? Evaluation { get; set; }

//         // Relation avec RéponseCandidat
//         public virtual ICollection<ReponseCandidat> ReponsesCandidats { get; set; } = new List<ReponseCandidat>();
//     }
// }
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Tentative
    {
        public int Id { get; set; }

        public DateTime DatePassage { get; set; }

        public float Score { get; set; }

        // Relation avec Candidat
        [ForeignKey("Candidat")]
        public int CandidatId { get; set; }
        public virtual Candidat? Candidat { get; set; }

        // Relation avec Evaluation (nullable)
        public int? EvaluationId { get; set; }
        public virtual Evaluation? Evaluation { get; set; }

        // Relation avec RéponseCandidat
        public virtual ICollection<ReponseCandidat> ReponsesCandidats { get; set; } = new List<ReponseCandidat>();
    }
}