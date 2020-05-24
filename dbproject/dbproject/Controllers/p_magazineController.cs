using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dbproject;

namespace dbproject.Controllers
{
    public class p_magazineController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_magazine
        public ActionResult Index()
        {
            return View(db.p_magazine.ToList());
        }

        // GET: p_magazine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_magazine p_magazine = db.p_magazine.Find(id);
            if (p_magazine == null)
            {
                return HttpNotFound();
            }
            return View(p_magazine);
        }

        // GET: p_magazine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_magazine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "magazine_id,magazine_name")] p_magazine p_magazine)
        {
            if (ModelState.IsValid)
            {
                db.p_magazine.Add(p_magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_magazine);
        }

        // GET: p_magazine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_magazine p_magazine = db.p_magazine.Find(id);
            if (p_magazine == null)
            {
                return HttpNotFound();
            }
            return View(p_magazine);
        }

        // POST: p_magazine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "magazine_id,magazine_name")] p_magazine p_magazine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_magazine);
        }

        // GET: p_magazine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_magazine p_magazine = db.p_magazine.Find(id);
            if (p_magazine == null)
            {
                return HttpNotFound();
            }
            return View(p_magazine);
        }

        // POST: p_magazine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_magazine p_magazine = db.p_magazine.Find(id);
            db.p_magazine.Remove(p_magazine);
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
