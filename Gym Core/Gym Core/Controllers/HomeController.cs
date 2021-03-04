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

        public IActionResult About()
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
        public IActionResult Connect([Bind("NomUtilisateur,MotdepasseUtilisateur")] Utilisateur utilisateur)
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

        public IActionResult Dashboard()
        {
            var members = _context.Membres
                .Join(
                    _context.Payements,
                    members => members.Id,
                    payements => payements.Membre,
                    (members, payements) => new
                    {
                        MembreId = members.Id,
                        MembreNom = members.NomMembre,
                        MembrePrenom = members.PrenomMembre,
                        LastpayementIn = (DateTime.Today - payements.DatePayement).Value.TotalDays
                    }
                ).ToList();

            List<MembreNonPayee> membs = new List<MembreNonPayee>();
            foreach(var v in members)
            {
                if (v.LastpayementIn > 29)
                {
                    MembreNonPayee n = new MembreNonPayee();
                    n.MembreId = v.MembreId;
                    n.MembreNom = v.MembreNom;
                    n.MembrePrenom = v.MembrePrenom;
                    n.LastpayementIn = v.LastpayementIn;
                    membs.Add(n);
                }
            }

            var memb = from u in _context.Membres
                       join p in _context.Payements on u.Id equals p.Membre into gj
                       from x in gj.DefaultIfEmpty()
                       where x.Id == null
                                   select new
                                   {
                                       Id = u.Id,
                                       NomMembre = u.NomMembre,
                                       PrenomMembre = u.PrenomMembre
                                   };

            foreach (var v in memb)
            {
                MembreNonPayee n = new MembreNonPayee();
                n.MembreId = v.Id;
                n.MembreNom = v.NomMembre;
                n.MembrePrenom = v.PrenomMembre;
                n.LastpayementIn = -1;
                membs.Add(n);
            }


            return View(membs);
        }
    }
}
