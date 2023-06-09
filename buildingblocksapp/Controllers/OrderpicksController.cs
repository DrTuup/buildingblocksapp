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
    public class OrderpicksController : Controller
    {
        private buildingblocksdbContext db = new buildingblocksdbContext();

        // GET: Orderpicks
        public ActionResult Index()
        {
            var orderpicks = db.Orderpicks.Include(o => o.Werkorder);
            return View(orderpicks.ToList());
        }

        // GET: Orderpicks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderpick orderpick = db.Orderpicks.Find(id);
            if (orderpick == null)
            {
                return HttpNotFound();
            }
            return View(orderpick);
        }

        // GET: Orderpicks/Create
        public ActionResult Create()
        {
            ViewBag.werkorderid = new SelectList(db.Werkorders, "werkorderid", "productielijn");
            return View();
        }

        // POST: Orderpicks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderpickid,werkorderid,periodeAanvraag,periodeLevering,rood,grijs,blauw,akkoordProductie")] Orderpick orderpick)
        {
            if (ModelState.IsValid)
            {
                db.Orderpicks.Add(orderpick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.werkorderid = new SelectList(db.Werkorders, "werkorderid", "productielijn", orderpick.werkorderid);
            return View(orderpick);
        }

        // GET: Orderpicks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderpick orderpick = db.Orderpicks.Find(id);
            if (orderpick == null)
            {
                return HttpNotFound();
            }
            ViewBag.werkorderid = new SelectList(db.Werkorders, "werkorderid", "productielijn", orderpick.werkorderid);
            return View(orderpick);
        }

        // POST: Orderpicks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderpickid,werkorderid,periodeAanvraag,periodeLevering,rood,grijs,blauw,akkoordProductie")] Orderpick orderpick)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderpick).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.werkorderid = new SelectList(db.Werkorders, "werkorderid", "productielijn", orderpick.werkorderid);
            return View(orderpick);
        }

        // GET: Orderpicks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderpick orderpick = db.Orderpicks.Find(id);
            if (orderpick == null)
            {
                return HttpNotFound();
            }
            return View(orderpick);
        }

        // POST: Orderpicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Orderpick orderpick = db.Orderpicks.Find(id);
            db.Orderpicks.Remove(orderpick);
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
