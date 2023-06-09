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
    public class InkoopordersController : Controller
    {
        private buildingblocksdbContext db = new buildingblocksdbContext();

        // GET: Inkooporders
        public ActionResult Index()
        {
            var inkooporders = db.Inkooporders.Include(i => i.Inkoopordercorrectie);
            return View(inkooporders.ToList());
        }

        // GET: Inkooporders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkooporder inkooporder = db.Inkooporders.Find(id);
            if (inkooporder == null)
            {
                return HttpNotFound();
            }
            return View(inkooporder);
        }

        // GET: Inkooporders/Create
        public ActionResult Create()
        {
            ViewBag.inkooporderid = new SelectList(db.Inkoopordercorrecties, "inkooporderid", "inkooporderid");
            return View();
        }

        // POST: Inkooporders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inkooporderid,periodeBinnenkomst,periodeVerwerkt,rood,grijs,blauw")] Inkooporder inkooporder)
        {
            if (ModelState.IsValid)
            {
                db.Inkooporders.Add(inkooporder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.inkooporderid = new SelectList(db.Inkoopordercorrecties, "inkooporderid", "inkooporderid", inkooporder.inkooporderid);
            return View(inkooporder);
        }

        // GET: Inkooporders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkooporder inkooporder = db.Inkooporders.Find(id);
            if (inkooporder == null)
            {
                return HttpNotFound();
            }
            ViewBag.inkooporderid = new SelectList(db.Inkoopordercorrecties, "inkooporderid", "inkooporderid", inkooporder.inkooporderid);
            return View(inkooporder);
        }

        // POST: Inkooporders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inkooporderid,periodeBinnenkomst,periodeVerwerkt,rood,grijs,blauw")] Inkooporder inkooporder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inkooporder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.inkooporderid = new SelectList(db.Inkoopordercorrecties, "inkooporderid", "inkooporderid", inkooporder.inkooporderid);
            return View(inkooporder);
        }

        // GET: Inkooporders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkooporder inkooporder = db.Inkooporders.Find(id);
            if (inkooporder == null)
            {
                return HttpNotFound();
            }
            return View(inkooporder);
        }

        // POST: Inkooporders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Inkooporder inkooporder = db.Inkooporders.Find(id);
            db.Inkooporders.Remove(inkooporder);
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
