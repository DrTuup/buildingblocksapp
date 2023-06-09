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
    public class InkoopordercorrectiesController : Controller
    {
        private buildingblocksdbContext db = new buildingblocksdbContext();

        // GET: Inkoopordercorrecties
        public ActionResult Index()
        {
            var inkoopordercorrecties = db.Inkoopordercorrecties.Include(i => i.Inkooporder);
            return View(inkoopordercorrecties.ToList());
        }

        // GET: Inkoopordercorrecties/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkoopordercorrectie inkoopordercorrectie = db.Inkoopordercorrecties.Find(id);
            if (inkoopordercorrectie == null)
            {
                return HttpNotFound();
            }
            return View(inkoopordercorrectie);
        }

        // GET: Inkoopordercorrecties/Create
        public ActionResult Create()
        {
            ViewBag.inkooporderid = new SelectList(db.Inkooporders, "inkooporderid", "inkooporderid");
            return View();
        }

        // POST: Inkoopordercorrecties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inkooporderid,rood,grijs,blauw")] Inkoopordercorrectie inkoopordercorrectie)
        {
            if (ModelState.IsValid)
            {
                db.Inkoopordercorrecties.Add(inkoopordercorrectie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.inkooporderid = new SelectList(db.Inkooporders, "inkooporderid", "inkooporderid", inkoopordercorrectie.inkooporderid);
            return View(inkoopordercorrectie);
        }

        // GET: Inkoopordercorrecties/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkoopordercorrectie inkoopordercorrectie = db.Inkoopordercorrecties.Find(id);
            if (inkoopordercorrectie == null)
            {
                return HttpNotFound();
            }
            ViewBag.inkooporderid = new SelectList(db.Inkooporders, "inkooporderid", "inkooporderid", inkoopordercorrectie.inkooporderid);
            return View(inkoopordercorrectie);
        }

        // POST: Inkoopordercorrecties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inkooporderid,rood,grijs,blauw")] Inkoopordercorrectie inkoopordercorrectie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inkoopordercorrectie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.inkooporderid = new SelectList(db.Inkooporders, "inkooporderid", "inkooporderid", inkoopordercorrectie.inkooporderid);
            return View(inkoopordercorrectie);
        }

        // GET: Inkoopordercorrecties/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inkoopordercorrectie inkoopordercorrectie = db.Inkoopordercorrecties.Find(id);
            if (inkoopordercorrectie == null)
            {
                return HttpNotFound();
            }
            return View(inkoopordercorrectie);
        }

        // POST: Inkoopordercorrecties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Inkoopordercorrectie inkoopordercorrectie = db.Inkoopordercorrecties.Find(id);
            db.Inkoopordercorrecties.Remove(inkoopordercorrectie);
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
