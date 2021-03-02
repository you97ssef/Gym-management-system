using Gym_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gym_Core.Controllers
{
    public class HomeController : Controller
    {

        private readonly GymContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, GymContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connect([Bind("NomUtilisateur,MotdepasseUtilisateur")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Utilisateurs.FirstOrDefault(a => a.NomUtilisateur == utilisateur.NomUtilisateur);
                if(user.MotdepasseUtilisateur == utilisateur.MotdepasseUtilisateur)
                {
                    HttpContext.Session.SetString("User", "Connected");
                    return Redirect("/payements");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

    }
}
