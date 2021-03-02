using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym_Core.Models;

namespace Gym_Core.Controllers
{
    public class MembresController : Controller
    {
        private readonly GymContext _context;

        public MembresController(GymContext context)
        {
            _context = context;
        }

        // GET: Membres
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Membres.Include(m => m.GroupeNavigation);
            return View(await gymContext.ToListAsync());
        }

        // GET: Membres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres
                .Include(m => m.GroupeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // GET: Membres/Create
        public IActionResult Create()
        {
            ViewData["Groupe"] = new SelectList(_context.Groupes, "Id", "Id");
            return View();
        }

        // POST: Membres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomMembre,PrenomMembre,DatenaissanceMembre,ContactMembre,DatejointureMembre,Groupe")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Groupe"] = new SelectList(_context.Groupes, "Id", "Id", membre.Groupe);
            return View(membre);
        }

        // GET: Membres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres.FindAsync(id);
            if (membre == null)
            {
                return NotFound();
            }
            ViewData["Groupe"] = new SelectList(_context.Groupes, "Id", "Id", membre.Groupe);
            return View(membre);
        }

        // POST: Membres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomMembre,PrenomMembre,DatenaissanceMembre,ContactMembre,DatejointureMembre,Groupe")] Membre membre)
        {
            if (id != membre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreExists(membre.Id))
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
            ViewData["Groupe"] = new SelectList(_context.Groupes, "Id", "Id", membre.Groupe);
            return View(membre);
        }

        // GET: Membres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membre = await _context.Membres
                .Include(m => m.GroupeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membre = await _context.Membres.FindAsync(id);
            _context.Membres.Remove(membre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreExists(int id)
        {
            return _context.Membres.Any(e => e.Id == id);
        }
    }
}
