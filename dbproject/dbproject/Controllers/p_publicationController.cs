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
    public class p_publicationController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_publication
        public ActionResult Index()
        {
            var p_publication = db.p_publication.Include(p => p.p_magazine);
            return View(p_publication.ToList());
        }

        // GET: p_publication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_publication p_publication = db.p_publication.Find(id);
            if (p_publication == null)
            {
                return HttpNotFound();
            }
            return View(p_publication);
        }

        // GET: p_publication/Create
        public ActionResult Create()
        {
            ViewBag.magazine_id = new SelectList(db.p_magazine, "magazine_id", "magazine_name");
            return View();
        }

        // POST: p_publication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "publication_id,volume_number,published_date,magazine_id")] p_publication p_publication)
        {
            if (ModelState.IsValid)
            {
                db.p_publication.Add(p_publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.magazine_id = new SelectList(db.p_magazine, "magazine_id", "magazine_name", p_publication.magazine_id);
            return View(p_publication);
        }

        // GET: p_publication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_publication p_publication = db.p_publication.Find(id);
            if (p_publication == null)
            {
                return HttpNotFound();
            }
            ViewBag.magazine_id = new SelectList(db.p_magazine, "magazine_id", "magazine_name", p_publication.magazine_id);
            return View(p_publication);
        }

        // POST: p_publication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "publication_id,volume_number,published_date,magazine_id")] p_publication p_publication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_publication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.magazine_id = new SelectList(db.p_magazine, "magazine_id", "magazine_name", p_publication.magazine_id);
            return View(p_publication);
        }

        // GET: p_publication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_publication p_publication = db.p_publication.Find(id);
            if (p_publication == null)
            {
                return HttpNotFound();
            }
            return View(p_publication);
        }

        // POST: p_publication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_publication p_publication = db.p_publication.Find(id);
            db.p_publication.Remove(p_publication);
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
