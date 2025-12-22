using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class StatistiquesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StatistiquesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            // KPIs
            var totalCandidats = await _db.Candidats.CountAsync();
            var candidatsReussis = await _db.Candidats.CountAsync(c => c.ScoreGlobal >= 60);
            var tauxReussite = totalCandidats > 0 ? (candidatsReussis * 100.0 / totalCandidats) : 0;

            var entretiensThisMonth = await _db.Entretiens
                .Where(e => e.DateEntretien.Month == DateTime.Now.Month && e.DateEntretien.Year == DateTime.Now.Year)
                .CountAsync();

            var candidatsEmbauches = await _db.Candidats.CountAsync(c => c.Statut == "Embauché");

            // Répartition par statut
            var statutsRepartition = await _db.Candidats
                .GroupBy(c => c.Statut)
                .Select(g => new { Statut = g.Key, Count = g.Count() })
                .ToListAsync();

            // Top 10 candidats
            var topCandidats = await _db.Candidats
                .Where(c => c.ScoreGlobal.HasValue)
                .OrderByDescending(c => c.ScoreGlobal)
                .Take(10)
                .ToListAsync();

            // Candidatures par mois (6 derniers mois)
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);
            var candidaturesParMois = await _db.Candidatures
                .Where(c => c.DateCandidature >= sixMonthsAgo)
                .GroupBy(c => new { c.DateCandidature.Year, c.DateCandidature.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToListAsync();

            // Scores moyens par évaluation
            var scoresMoyens = await _db.Tentatives
                .Include(t => t.Evaluation)
                .GroupBy(t => t.Evaluation.Titre)
                .Select(g => new
                {
                    Evaluation = g.Key,
                    ScoreMoyen = g.Average(t => t.Score)
                })
                .ToListAsync();

            ViewBag.TotalCandidats = totalCandidats;
            ViewBag.TauxReussite = tauxReussite;
            ViewBag.EntretiensThisMonth = entretiensThisMonth;
            ViewBag.CandidatsEmbauches = candidatsEmbauches;
            ViewBag.StatutsRepartition = statutsRepartition;
            ViewBag.TopCandidats = topCandidats;
            ViewBag.CandidaturesParMois = candidaturesParMois;
            ViewBag.ScoresMoyens = scoresMoyens;

            return View();
        }
    }
}






