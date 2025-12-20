namespace WebApplication1.Models
{
    public class PasserEvaluationViewModel
    {
        public int EvaluationId { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int DureeMinutes { get; set; }

        public List<QuestionAvecReponse> Questions { get; set; }
    }

    public class QuestionAvecReponse
    {
        public int QuestionId { get; set; }
        public string Texte { get; set; }
        public List<OptionReponse> Options { get; set; }

        // User's answer
        public int? SelectedOptionId { get; set; }
    }
}
