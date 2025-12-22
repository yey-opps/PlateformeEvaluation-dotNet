using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;


namespace WebApplication1.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

        public EvaluationsController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }





        // ============================================================
        // YOUR FRIEND'S PART — CRUD
        // ============================================================

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evaluations.ToListAsync());
        }

        // GET: Evaluations/Details/5  (your friend)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var evaluation = await _context.Evaluations
                .FirstOrDefaultAsync(m => m.Id == id);

            if (evaluation == null)
                return NotFound();

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evaluations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Description,DureeMinutes,DateCreation")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null)
                return NotFound();

            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,DureeMinutes,DateCreation")] Evaluation evaluation)
        {
            if (id != evaluation.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluationExists(evaluation.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var evaluation = await _context.Evaluations
                .FirstOrDefaultAsync(m => m.Id == id);

            if (evaluation == null)
                return NotFound();

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.Id == id);
        }


        // ============================================================
        // YOUR PART — PASSER, SCORING, QUESTIONS, OPTIONS
        // ============================================================

        // GET: Evaluate with questions & options
public async Task<IActionResult> PasserEvaluation(int id)
{
    var evaluation = await _context.Evaluations
        .Include(e => e.Questions)
            .ThenInclude(q => q.Options)
        .FirstOrDefaultAsync(e => e.Id == id);

    if (evaluation == null)
        return NotFound();

    var vm = new PasserEvaluationViewModel
    {
        EvaluationId = evaluation.Id,
        Titre = evaluation.Titre,
        Description = evaluation.Description,
        DureeMinutes = evaluation.DureeMinutes,

        Questions = evaluation.Questions.Select(q => new QuestionAvecReponse
        {
            QuestionId = q.Id,
            Texte = q.Texte,
            Options = q.Options.ToList(),
            SelectedOptionId = null
        }).ToList()
    };

    return View(vm);
}
[HttpPost]
[ValidateAntiForgeryToken]

public async Task<IActionResult> Submit(PasserEvaluationViewModel model)
{
    if (model == null || model.Questions == null || !model.Questions.Any())
        return BadRequest("Aucune réponse envoyée.");

    // Get current logged-in user
    var user = await _userManager.GetUserAsync(User);
    
    // Find or create candidat
    Candidat candidat = null;
    
    if (user != null)
    {
        candidat = await _context.Candidats
            .FirstOrDefaultAsync(c => c.UserId == user.Id);

        if (candidat == null)
        {
            candidat = new Candidat
            {
                Email = user.Email ?? "",
                Nom = user.UserName ?? "Unknown",
                Prenom = "",
                UserId = user.Id
            };
            _context.Candidats.Add(candidat);
            await _context.SaveChangesAsync();
        }
    }
    else
    {
        return RedirectToPage("/Account/Login", new { area = "Identity" });
    }

    // Calculate score
    int correctAnswers = 0;
    int totalQuestions = model.Questions.Count;

    foreach (var q in model.Questions)
    {
        var correctOption = await _context.OptionsReponse
            .Where(o => o.QuestionId == q.QuestionId && o.EstCorrecte)
            .FirstOrDefaultAsync();

        if (correctOption != null && q.SelectedOptionId == correctOption.Id)
            correctAnswers++;
    }

    // Calculate percentage score
    float scorePercentage = totalQuestions > 0 
        ? (float)correctAnswers / totalQuestions * 100 
        : 0;

    // SAVE TENTATIVE TO DATABASE
    var tentative = new Tentative
    {
        CandidatId = candidat.Id,
        EvaluationId = model.EvaluationId,
        DatePassage = DateTime.Now,
        Score = scorePercentage
    };

    _context.Tentatives.Add(tentative);
    await _context.SaveChangesAsync();

    // SAVE INDIVIDUAL RESPONSES
    foreach (var q in model.Questions)
    {
        var reponse = new ReponseCandidat
        {
            TentativeId = tentative.Id,
            QuestionId = q.QuestionId,
            OptionReponseId = q.SelectedOptionId,
            ReponseTexte = q.SelectedOptionId?.ToString() ?? ""
        };
        _context.ReponsesCandidats.Add(reponse);

    }

    await _context.SaveChangesAsync();
            // ============ MISE À JOUR DU STATUT CANDIDAT ============
            // Récupérer toutes les tentatives du candidat
            var toutesTentatives = await _context.Tentatives
                .Where(t => t.CandidatId == candidat.Id)
                .ToListAsync();

            // Calculer le score global (moyenne de toutes les tentatives)
            if (toutesTentatives.Any())
            {
                float scoreGlobal = toutesTentatives.Average(t => t.Score);
                candidat.ScoreGlobal = scoreGlobal;

                // Mettre à jour le statut selon le score
                if (scoreGlobal >= 60)
                {
                    candidat.Statut = "Réussi aux tests";
                }
                else
                {
                    candidat.Statut = "Échec aux tests";
                }

                await _context.SaveChangesAsync();
            }

            // ✅ FIX: Store everything as STRINGS or basic types only
            TempData["Score"] = correctAnswers.ToString();
    TempData["Total"] = totalQuestions.ToString();
    TempData["Percentage"] = scorePercentage.ToString("F1"); // ✅ Convert to string
    TempData["EvaluationTitle"] = model.Titre;

    // CHECK FOR NEXT EVALUATION
    int nextId = model.EvaluationId + 1;
    var nextEvaluation = await _context.Evaluations
        .Include(e => e.Questions)
        .Where(e => e.Id >= nextId && e.Questions.Any())
        .OrderBy(e => e.Id)
        .FirstOrDefaultAsync();

    if (nextEvaluation != null)
    {
        TempData["NextEvaluationId"] = nextEvaluation.Id.ToString();
        TempData["NextEvaluationTitle"] = nextEvaluation.Titre;
    }

    return RedirectToAction("Resultat");
}
public IActionResult Resultat()
{
    return View();
}

    }
}





// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using WebApplication1.Data;
// using WebApplication1.Models;

// namespace WebApplication1.Controllers
// {
//     public class EvaluationsController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public EvaluationsController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         // GET: Evaluations
//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Evaluations.ToListAsync());
//         }

//         // GET: Evaluations/Details/5
//         public async Task<IActionResult> Details(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var evaluation = await _context.Evaluations
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (evaluation == null)
//             {
//                 return NotFound();
//             }

//             return View(evaluation);
//         }

//         // GET: Evaluations/Create
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // POST: Evaluations/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Id,Titre,Description,DureeMinutes,DateCreation")] Evaluation evaluation)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Add(evaluation);
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(evaluation);
//         }

//         // GET: Evaluations/Edit/5
//         public async Task<IActionResult> Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var evaluation = await _context.Evaluations.FindAsync(id);
//             if (evaluation == null)
//             {
//                 return NotFound();
//             }
//             return View(evaluation);
//         }

//         // POST: Evaluations/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Description,DureeMinutes,DateCreation")] Evaluation evaluation)
//         {
//             if (id != evaluation.Id)
//             {
//                 return NotFound();
//             }

//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(evaluation);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!EvaluationExists(evaluation.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(evaluation);
//         }

//         // GET: Evaluations/Delete/5
//         public async Task<IActionResult> Delete(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var evaluation = await _context.Evaluations
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (evaluation == null)
//             {
//                 return NotFound();
//             }

//             return View(evaluation);
//         }

//         // POST: Evaluations/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             var evaluation = await _context.Evaluations.FindAsync(id);
//             if (evaluation != null)
//             {
//                 _context.Evaluations.Remove(evaluation);
//             }

//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }

//         private bool EvaluationExists(int id)
//         {
//             return _context.Evaluations.Any(e => e.Id == id);
//         }
//     }
// }
