using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CandidatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Candidats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidats.ToListAsync());
        }

        // GET: Candidats/Details/5
        // GET: Candidats/Details/5
// GET: Candidats/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null)
        return NotFound();

    var candidat = await _context.Candidats
        .Include(c => c.Candidatures)
        .Include(c => c.Tentatives)
            .ThenInclude(t => t.Evaluation)
                .ThenInclude(e => e.Questions)
        .Include(c => c.Tentatives)
            .ThenInclude(t => t.ReponsesCandidats)
        .FirstOrDefaultAsync(m => m.Id == id);

    if (candidat == null)
        return NotFound();

    return View(candidat);
}
        // GET: Candidats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,MotDePasse")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidat);
        }

        // GET: Candidats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            return View(candidat);
        }

        // POST: Candidats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,MotDePasse")] Candidat candidat)
        {
            if (id != candidat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatExists(candidat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidat);
        }

        // GET: Candidats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidat == null)
            {
                return NotFound();
            }

            return View(candidat);
        }

        // POST: Candidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat != null)
            {
                _context.Candidats.Remove(candidat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatExists(int id)
        {
            return _context.Candidats.Any(e => e.Id == id);
        }
    }
}
