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
    public class WerkordersController : Controller
    {
        private buildingblocksdbContext db = new buildingblocksdbContext();

        // GET: Werkorders
        public ActionResult Index()
        {
            var werkorders = db.Werkorders.Include(w => w.Klantorder);
            return View(werkorders.ToList());
        }

        // GET: Werkorders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkorder werkorder = db.Werkorders.Find(id);
            if (werkorder == null)
            {
                return HttpNotFound();
            }
            return View(werkorder);
        }

        // GET: Werkorders/Create
        public ActionResult Create()
        {
            ViewBag.orderid = new SelectList(db.Klantorders, "orderid", "naam");
            return View();
        }

        // POST: Werkorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "werkorderid,orderid,productielijn,leverperiode,akkoordPlanning,akkoordAccountmanager")] Werkorder werkorder)
        {
            if (ModelState.IsValid)
            {
                db.Werkorders.Add(werkorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderid = new SelectList(db.Klantorders, "orderid", "naam", werkorder.orderid);
            return View(werkorder);
        }

        // GET: Werkorders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkorder werkorder = db.Werkorders.Find(id);
            if (werkorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderid = new SelectList(db.Klantorders, "orderid", "naam", werkorder.orderid);
            return View(werkorder);
        }

        // POST: Werkorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "werkorderid,orderid,productielijn,leverperiode,akkoordPlanning,akkoordAccountmanager")] Werkorder werkorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(werkorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderid = new SelectList(db.Klantorders, "orderid", "naam", werkorder.orderid);
            return View(werkorder);
        }

        // GET: Werkorders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkorder werkorder = db.Werkorders.Find(id);
            if (werkorder == null)
            {
                return HttpNotFound();
            }
            return View(werkorder);
        }

        // POST: Werkorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Werkorder werkorder = db.Werkorders.Find(id);
            db.Werkorders.Remove(werkorder);
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
