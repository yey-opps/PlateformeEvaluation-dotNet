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
    public class TentativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TentativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tentatives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tentatives.Include(t => t.Candidat).Include(t => t.Evaluation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tentatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tentative = await _context.Tentatives
                .Include(t => t.Candidat)
                .Include(t => t.Evaluation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tentative == null)
            {
                return NotFound();
            }

            return View(tentative);
        }

        // GET: Tentatives/Create
        public IActionResult Create()
        {
            ViewData["CandidatId"] = new SelectList(_context.Candidats, "Id", "Id");
            ViewData["EvaluationId"] = new SelectList(_context.Evaluations, "Id", "Titre");
            return View();
        }

        // POST: Tentatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatePassage,Score,CandidatId,EvaluationId")] Tentative tentative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tentative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatId"] = new SelectList(_context.Candidats, "Id", "Id", tentative.CandidatId);
            ViewData["EvaluationId"] = new SelectList(_context.Evaluations, "Id", "Titre", tentative.EvaluationId);
            return View(tentative);
        }

        // GET: Tentatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tentative = await _context.Tentatives.FindAsync(id);
            if (tentative == null)
            {
                return NotFound();
            }
            ViewData["CandidatId"] = new SelectList(_context.Candidats, "Id", "Id", tentative.CandidatId);
            ViewData["EvaluationId"] = new SelectList(_context.Evaluations, "Id", "Titre", tentative.EvaluationId);
            return View(tentative);
        }

        // POST: Tentatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatePassage,Score,CandidatId,EvaluationId")] Tentative tentative)
        {
            if (id != tentative.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tentative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TentativeExists(tentative.Id))
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
            ViewData["CandidatId"] = new SelectList(_context.Candidats, "Id", "Id", tentative.CandidatId);
            ViewData["EvaluationId"] = new SelectList(_context.Evaluations, "Id", "Titre", tentative.EvaluationId);
            return View(tentative);
        }

        // GET: Tentatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tentative = await _context.Tentatives
                .Include(t => t.Candidat)
                .Include(t => t.Evaluation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tentative == null)
            {
                return NotFound();
            }

            return View(tentative);
        }

        // POST: Tentatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tentative = await _context.Tentatives.FindAsync(id);
            if (tentative != null)
            {
                _context.Tentatives.Remove(tentative);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TentativeExists(int id)
        {
            return _context.Tentatives.Any(e => e.Id == id);
        }
    }
}
