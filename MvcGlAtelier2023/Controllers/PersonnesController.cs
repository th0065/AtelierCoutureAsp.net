using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGlAtelier2023.Models;

namespace MvcGlAtelier2023.Controllers
{
    public class PersonnesController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();

        // GET: Personnes
        public ActionResult Index()
        {
            return View(db.personnes.ToList());
        }

        // GET: Personnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // GET: Personnes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPers,NomPers,PrenomPers,AdressePers,EmailPers,TelPers")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                db.personnes.Add(personne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personne);
        }

        // GET: Personnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPers,NomPers,PrenomPers,AdressePers,EmailPers,TelPers")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personne personne = db.personnes.Find(id);
            if (personne == null)
            {
                return HttpNotFound();
            }
            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personne personne = db.personnes.Find(id);
            db.personnes.Remove(personne);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
