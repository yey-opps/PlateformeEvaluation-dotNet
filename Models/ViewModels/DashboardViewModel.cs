using WebApplication1.Models;

namespace WebApplication1.Models.ViewModels
{
    public class DashboardViewModel
    {
        public string UserName { get; set; } = "Utilisateur";
        public int TotalCandidats { get; set; }
        public int TotalEvaluationsTerminees { get; set; }
        public int EvaluationsTermineesCetteSemaine { get; set; }
        public double ScoreMoyen { get; set; }
        public int InProgressCount { get; set; }  
        public int TentativesNonTerminees { get; set; }

        public List<Evaluation> AvailableEvaluations { get; set; } = new();
        public List<Tentative> RecentTentatives { get; set; } = new();
    }
}