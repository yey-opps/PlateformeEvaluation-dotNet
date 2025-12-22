using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class CandidaturesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailService _emailService;

        public CandidaturesController(ApplicationDbContext db, IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        // ?? LISTE DES CANDIDATURES (HR/Admin)
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var candidatures = await _db.Candidatures
                .Include(c => c.Candidat)
                .OrderByDescending(c => c.DateCandidature)
                .ToListAsync();

            return View(candidatures);
        }

        // ?? PAGE PUBLIQUE - Postuler avec CV (CONNEXION REQUISE)
        public IActionResult Postuler()
        {
            // FORCER LA CONNEXION
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect($"/Identity/Account/Login?ReturnUrl={Uri.EscapeDataString("/Candidatures/Postuler")}");
            }

            return View();
        }

        // ?? UPLOAD DU CV
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Postuler(string nom, string prenom, string email, IFormFile cvPdf)
        {
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(email) || cvPdf == null)
            {
                TempData["Error"] = "Veuillez remplir tous les champs et uploader votre CV.";
                return View();
            }

            // Vérifier si le candidat existe déjà
            var candidatExistant = await _db.Candidats.FirstOrDefaultAsync(c => c.Email == email);

            Candidat candidat;
            if (candidatExistant != null)
            {
                candidat = candidatExistant;
            }
            else
            {
                // Créer un nouveau candidat
                candidat = new Candidat
                {
                    Nom = nom,
                    Prenom = prenom,
                    Email = email,
                    Statut = "CV en attente"
                };
                _db.Candidats.Add(candidat);
                await _db.SaveChangesAsync();
            }

            // Sauvegarder le PDF
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "cvs");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{cvPdf.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await cvPdf.CopyToAsync(fileStream);
            }

            // Créer la candidature
            var candidature = new Candidature
            {
                CandidatId = candidat.Id,
                Statut = "En attente",
                DateCandidature = DateTime.Now,
                CvPdfPath = $"/uploads/cvs/{uniqueFileName}",
                EmailEnvoye = false
            };

            _db.Candidatures.Add(candidature);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Votre CV a été envoyé avec succès ! Vous recevrez un email si votre candidature est validée.";
            return RedirectToAction("Confirmation");
        }

        // ? PAGE DE CONFIRMATION
        [AllowAnonymous]
        public IActionResult Confirmation()
        {
            return View();
        }

        // ? VALIDER UNE CANDIDATURE (HR/Admin)
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Valider(int id)
        {
            var candidature = await _db.Candidatures
                .Include(c => c.Candidat)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (candidature == null)
                return NotFound();

            // Mettre à jour la candidature
            candidature.Statut = "Validé";
            candidature.DateApprobation = DateTime.Now;
            candidature.EmailEnvoye = true;

            // Mettre à jour le statut du candidat
            if (candidature.Candidat != null)
            {
                candidature.Candidat.Statut = "Éligible aux tests";
            }

            await _db.SaveChangesAsync();

            // Envoyer l'email
            var lienTest = Url.Action("PasserEvaluation", "Evaluations", new { id = 1 }, Request.Scheme);
            await _emailService.EnvoyerEmailValidationAsync(
                candidature.Candidat.Email,
                $"{candidature.Candidat.Prenom} {candidature.Candidat.Nom}",
                lienTest
            );

            TempData["Success"] = $"Candidature validée ! Email envoyé à {candidature.Candidat.Email}";
            return RedirectToAction("Index");
        }   
        
        // ? REJETER UNE CANDIDATURE (HR/Admin)
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Rejeter(int id, string commentaire)
        {
            var candidature = await _db.Candidatures
                .Include(c => c.Candidat)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (candidature == null)
                return NotFound();

            candidature.Statut = "Rejeté";
            candidature.CommentaireRejet = commentaire;
            candidature.Candidat.Statut = "Rejeté";

            await _db.SaveChangesAsync();

            TempData["Success"] = "Candidature rejetée.";
            return RedirectToAction("Index", "Candidats");
        }
    }
}