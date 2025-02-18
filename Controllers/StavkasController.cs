﻿using System;
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

namespace Faktura.Controllers
{
    public class StavkasController : Controller
    {
        private FakturaContext db = new FakturaContext();

        // GET: Stavkas
        public ActionResult Index()
        {
            return View(db.Stavke.ToList());
        }

        // GET: Stavkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // GET: Stavkas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stavkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStavka,OpisProdaneStavke,KolicinaProdaneStavke,CijenaStavkeBezPoreza,RacunId")] Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                
                StavkaRepository sr = new StavkaRepository();
                stavka.UkupnaCijenaStavkaBezPoreza = sr.IzracunCijene(stavka.KolicinaProdaneStavke, stavka.CijenaStavkeBezPoreza);
                db.Stavke.Add(stavka);
                db.SaveChanges();
                ModelState.Clear();
                return View();
            }

            return View(stavka);
        }

        // GET: Stavkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // POST: Stavkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStavka,OpisProdaneStavke,KolicinaProdaneStavke,CijenaStavkeBezPoreza,UkupnaCijenaStavkaBezPoreza,RacunId")] Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stavka);
        }

        // GET: Stavkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // POST: Stavkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stavka stavka = db.Stavke.Find(id);
            db.Stavke.Remove(stavka);
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
