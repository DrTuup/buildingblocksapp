using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using buildingblocksapp.Models;

namespace buildingblocksapp.Controllers
{
    public class KlantordersController : Controller
    {
        private buildingblocksdbContext db = new buildingblocksdbContext();

        // GET: Klantorders
        public ActionResult Index()
        {
            return View(db.Klantorders.ToList());
        }

        // GET: Klantorders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klantorder klantorder = db.Klantorders.Find(id);
            if (klantorder == null)
            {
                return HttpNotFound();
            }
            return View(klantorder);
        }

        // GET: Klantorders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klantorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderid,naam,aantal,type,referentienummer,akkoordAccountmanager")] Klantorder klantorder)
        {
            if (ModelState.IsValid)
            {
                db.Klantorders.Add(klantorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klantorder);
        }

        // GET: Klantorders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klantorder klantorder = db.Klantorders.Find(id);
            if (klantorder == null)
            {
                return HttpNotFound();
            }
            return View(klantorder);
        }

        // POST: Klantorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderid,naam,aantal,type,referentienummer,akkoordAccountmanager")] Klantorder klantorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klantorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klantorder);
        }

        // GET: Klantorders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klantorder klantorder = db.Klantorders.Find(id);
            if (klantorder == null)
            {
                return HttpNotFound();
            }
            return View(klantorder);
        }

        // POST: Klantorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Klantorder klantorder = db.Klantorders.Find(id);
            db.Klantorders.Remove(klantorder);
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
