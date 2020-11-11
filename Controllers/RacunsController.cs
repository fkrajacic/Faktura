using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Faktura.Data;
using Faktura.Models;
using Faktura.Repository;
using Microsoft.AspNet.Identity;

namespace Faktura.Controllers
{
    public class RacunsController : Controller
    {
        private FakturaContext db = new FakturaContext();

        // GET: Racuns
        public ActionResult Index()
        {
            return View(db.Racuni.ToList());
        }

        // GET: Racuns/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            StavkaRepository sr = new StavkaRepository();
            racun.stavke = sr.GetStavka(id);

      
           
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racuns/Create
        [Authorize]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Racuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Create([Bind(Include = "DatumDospijeca,UkupnaCijenaBezPoreza,UkupnaCijenaSPorezom,NazivPrimateljaRacuna")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                Stavka s = new Stavka();
                RacunRepository rr = new RacunRepository();
                racun.DateNow = rr.GetTodayDate();
                racun.ModifiedBy = rr.GetUser();
                db.Racuni.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(racun);
        }


        // GET: Racuns/Edit/5
        [Authorize]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrojFakture,UserId,DateNow,DatumDospijeca,UkupnaCijenaBezPoreza,UkupnaCijenaSPorezom,NazivPrimateljaRacuna")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racun);
        }


        // GET: Racuns/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

       
        // POST: Racuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racuni.Find(id);
            db.Racuni.Remove(racun);
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

