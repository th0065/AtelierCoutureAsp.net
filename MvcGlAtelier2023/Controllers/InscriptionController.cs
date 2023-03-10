using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MvcGlAtelier2023.Models;
using PagedList;


namespace MvcGlAtelier2023.Controllers
{
    
    public class InscriptionController : Controller
    {
        private bdAtelier2023Context db = new bdAtelier2023Context();

        int pageSize = 2;
        // POST: Clients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPers,NomPers,PrenomPers,AdressePers,EmailPers,TelPers,Sexe")] ClientViewModel cl)
        {
            if (ModelState.IsValid)
            {
                Personne p = new Personne();
                p.NomPers = cl.NomPers;
                p.PrenomPers = cl.PrenomPers;
                p.AdressePers = cl.AdressePers;
                p.EmailPers = cl.EmailPers;
                p.TelPers = cl.TelPers;
                db.personnes.Add(p);
                db.SaveChanges();
                Client c = new Client();
                c.IdPers = p.IdPers;
                c.Sexe = cl.Sexe;
                db.clients.Add(c);
                db.SaveChanges();
                return RedirectToAction("listerClient");
            }

            return View(cl);
        }
        //GET : Client/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult listerClient( int? page, String Nom, String Prenom)
        {
            page = page.HasValue ? page : 1;
            var liste = getListeClient();
            int pageNumber = (page ?? 1);
            ViewBag.Nom = Nom;
            ViewBag.Prenom = Prenom;
            if (!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a => a.NomPers.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.PrenomPers.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }

            return View(liste.ToPagedList(pageNumber, pageSize));
        }
        private List<ClientViewModel> getListeClient()
        {
            List<ClientViewModel> lister = new List<ClientViewModel>();

            var liste = db.clients.Join(db.personnes, x => x.IdPers, y=>y.IdPers,(x,y)=>
            new {x.IdPers,x.Sexe ,y.NomPers,y.PrenomPers,y.AdressePers,y.TelPers,y.EmailPers}).ToList();

            foreach(var item in liste)
            {
                ClientViewModel c = new ClientViewModel();

                c.NomPers = item.NomPers;
                c.PrenomPers = item.PrenomPers;
                c.AdressePers = item.AdressePers;
                c.TelPers = item.TelPers;
                c.EmailPers = item.EmailPers;
                c.Sexe = item.Sexe;
                lister.Add(c);
            }
            return lister;
        }

    }
}