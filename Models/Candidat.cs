namespace WebApplication1.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        
        public string Nom { get; set; } = string.Empty;
        
        public string Prenom { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        // Link to AspNetUsers
        public string? UserId { get; set; }

        // Navigation properties
        public ICollection<Tentative> Tentatives { get; set; } = new List<Tentative>();
        public ICollection<Candidature> Candidatures { get; set; } = new List<Candidature>();
    }
}