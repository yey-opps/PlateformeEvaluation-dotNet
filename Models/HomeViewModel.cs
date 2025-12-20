namespace WebApplication1.Models
{
    public class HomeViewModel
    {
        public int CandidatsCount { get; set; }
        public int EvaluationsCount { get; set; }
        public int TentativesCount { get; set; }
        // SuccessRate as integer percent (0-100)
        public int SuccessRate { get; set; }
    }
}
