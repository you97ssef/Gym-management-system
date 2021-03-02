using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym_Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gym_Core.Controllers
{
    public class PayementsController : Controller
    {
        private readonly GymContext _context;

        public PayementsController(GymContext context)
        {
            _context = context;
        }

        // GET: Payements
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Payements.Include(p => p.MembreNavigation);
            return View(await gymContext.ToListAsync());
        }

        // GET: Payements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payement = await _context.Payements
                .Include(p => p.MembreNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payement == null)
            {
                return NotFound();
            }

            return View(payement);
        }

        // GET: Payements/Create
        public IActionResult Create()
        {
            ViewData["Membre"] = new SelectList(_context.Membres, "Id", "Id");
            return View();
        }

        // POST: Payements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatePayement,MontantPayement,DescriptionPayement,Membre")] Payement payement)
        {
            if (ModelState.IsValid)
            {
                payement.DatePayement = DateTime.Now;
                if(_context.Payements.Count() == 0)
                {
                    payement.Id = 1;
                }
                else
                {
                    payement.Id = _context.Payements.Max(u => u.Id) + 1;
                }
                _context.Add(payement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Membre"] = new SelectList(_context.Membres, "Id", "Id", payement.Membre);
            return View(payement);
        }

        // GET: Payements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payement = await _context.Payements.FindAsync(id);
            if (payement == null)
            {
                return NotFound();
            }
            ViewData["Membre"] = new SelectList(_context.Membres, "Id", "Id", payement.Membre);
            return View(payement);
        }

        // POST: Payements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatePayement,MontantPayement,DescriptionPayement,Membre")] Payement payement)
        {
            if (id != payement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayementExists(payement.Id))
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
            ViewData["Membre"] = new SelectList(_context.Membres, "Id", "Id", payement.Membre);
            return View(payement);
        }

        // GET: Payements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payement = await _context.Payements
                .Include(p => p.MembreNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payement == null)
            {
                return NotFound();
            }

            return View(payement);
        }

        // POST: Payements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payement = await _context.Payements.FindAsync(id);
            _context.Payements.Remove(payement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayementExists(int id)
        {
            return _context.Payements.Any(e => e.Id == id);
        }
    }
}
