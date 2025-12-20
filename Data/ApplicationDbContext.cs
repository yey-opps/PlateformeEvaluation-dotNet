using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets pour toutes vos tables
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
        public DbSet<Tentative> Tentatives { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<OptionReponse> OptionsReponse { get; set; }
        public DbSet<ReponseCandidat> ReponsesCandidats { get; set; }

        // 🔥 IMPORTANT: Intégrer le seeder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appel du seeder
            EvaluationSeeder.SeedIntelligenceEvaluation(modelBuilder);
        }

        
    }
}
