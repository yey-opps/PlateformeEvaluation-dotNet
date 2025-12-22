using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class EntretiensController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailService _emailService;

        public EntretiensController(ApplicationDbContext db, IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        // ?? LISTE DES CANDIDATS QUALIFIÉS + ENTRETIENS
        public async Task<IActionResult> Index()
        {
            // Candidats qui ont réussi les tests (score >= 60%)
            var candidatsQualifies = await _db.Candidats
                .Where(c => c.Statut == "Réussi aux tests" || c.Statut == "Entretien programmé")
                .OrderByDescending(c => c.ScoreGlobal)
                .ToListAsync();

            // Entretiens programmés
            var entretiens = await _db.Entretiens
                .Include(e => e.Candidat)
                .OrderBy(e => e.DateEntretien)
                .ToListAsync();

            ViewBag.Entretiens = entretiens;

            return View(candidatsQualifies);
        }

        // ?? PROGRAMMER UN ENTRETIEN (AVEC EMAIL)
        [HttpPost]
        public async Task<IActionResult> Programmer(int candidatId, DateTime dateEntretien, string typeEntretien, string lieu)
        {
            var candidat = await _db.Candidats.FindAsync(candidatId);

            if (candidat == null)
                return NotFound();

            var entretien = new Entretien
            {
                CandidatId = candidatId,
                DateEntretien = dateEntretien,
                TypeEntretien = typeEntretien,
                Lieu = lieu,
                Statut = "Programmé"
            };

            _db.Entretiens.Add(entretien);

            // Mettre à jour le statut du candidat
            candidat.Statut = "Entretien programmé";

            await _db.SaveChangesAsync();

            // ENVOYER L'EMAIL
            try
            {
                await _emailService.EnvoyerEmailEntretienAsync(
                    candidat.Email,
                    $"{candidat.Prenom} {candidat.Nom}",
                    dateEntretien,
                    typeEntretien,
                    lieu
                );

                TempData["Success"] = $"Entretien programmé pour {candidat.Prenom} {candidat.Nom}. Email envoyé !";
            }
            catch (Exception ex)
            {
                TempData["Success"] = $"Entretien programmé pour {candidat.Prenom} {candidat.Nom} (Email non envoyé : {ex.Message})";
            }

            return RedirectToAction("Index");
        }

        // ? MARQUER COMME EMBAUCHÉ
        [HttpPost]
        public async Task<IActionResult> Embaucher(int entretienId)
        {
            var entretien = await _db.Entretiens
                .Include(e => e.Candidat)
                .FirstOrDefaultAsync(e => e.Id == entretienId);

            if (entretien == null)
                return NotFound();

            entretien.Statut = "Terminé";
            entretien.ResultatFinal = "Embauché";

            if (entretien.Candidat != null)
            {
                entretien.Candidat.Statut = "Embauché";
            }

            await _db.SaveChangesAsync();

            TempData["Success"] = "Candidat embauché !";
            return RedirectToAction("Index");
        }

        // ? REJETER APRÈS ENTRETIEN
        [HttpPost]
        public async Task<IActionResult> Rejeter(int entretienId, string commentaire)
        {
            var entretien = await _db.Entretiens
                .Include(e => e.Candidat)
                .FirstOrDefaultAsync(e => e.Id == entretienId);

            if (entretien == null)
                return NotFound();

            entretien.Statut = "Terminé";
            entretien.ResultatFinal = "Rejeté";
            entretien.Commentaire = commentaire;

            if (entretien.Candidat != null)
            {
                entretien.Candidat.Statut = "Rejeté";
            }

            await _db.SaveChangesAsync();

            TempData["Success"] = "Candidat rejeté.";
            return RedirectToAction("Index");
        }

        // ??? ANNULER UN ENTRETIEN
        [HttpPost]
        public async Task<IActionResult> Annuler(int entretienId)
        {
            var entretien = await _db.Entretiens
                .Include(e => e.Candidat)
                .FirstOrDefaultAsync(e => e.Id == entretienId);

            if (entretien == null)
                return NotFound();

            entretien.Statut = "Annulé";

            if (entretien.Candidat != null)
            {
                entretien.Candidat.Statut = "Réussi aux tests";
            }

            await _db.SaveChangesAsync();

            TempData["Success"] = "Entretien annulé.";
            return RedirectToAction("Index");
        }
    }
}