using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym_Management_system.Models;

namespace Gym_Management_system.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                Utilisateur u = new Utilisateur();
                u.getUtilisateur(collection["nom_utilisateur"]);
                if (u.nom_utilisateur == collection["nom_utilisateur"] && u.motdepasse_utilisateur == collection["motdepasse_utilisateur"])
                {
                    Session.Add("User", "connected");
                    return RedirectToAction("Dashboard");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard
        public ActionResult Dashboard()
        {
            if (Session["User"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }

        public ActionResult Deconnect()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch
            {
                return View("Dashboard");
            }
        }



        // GET: Utilisateur
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utilisateur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utilisateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if(collection["conf"] == collection["motdepasse_utilisateur"] && collection["nom_utilisateur"] != "")
                {
                    Utilisateur u = new Utilisateur();
                    if (u.createUtilisateur(collection["nom_utilisateur"], collection["motdepasse_utilisateur"]) == 1)
                        return RedirectToAction("Index");
                    else
                        return View();
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilisateur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utilisateur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Utilisateur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utilisateur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
