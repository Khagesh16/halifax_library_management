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
    public class p_articlesController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_articles
        public ActionResult Index()
        {
            var p_articles = db.p_articles.Include(p => p.p_publication);
            return View(p_articles.ToList());
        }

        // GET: p_articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_articles p_articles = db.p_articles.Find(id);
            if (p_articles == null)
            {
                return HttpNotFound();
            }
            return View(p_articles);
        }

        // GET: p_articles/Create
        public ActionResult Create()
        {
            ViewBag.publication_id = new SelectList(db.p_publication, "publication_id", "publication_id");
            return View();
        }

        // POST: p_articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "article_id,title,page_no,publication_id")] p_articles p_articles)
        {
            if (ModelState.IsValid)
            {
                db.p_articles.Add(p_articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.publication_id = new SelectList(db.p_publication, "publication_id", "publication_id", p_articles.publication_id);
            return View(p_articles);
        }

        // GET: p_articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_articles p_articles = db.p_articles.Find(id);
            if (p_articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.publication_id = new SelectList(db.p_publication, "publication_id", "publication_id", p_articles.publication_id);
            return View(p_articles);
        }

        // POST: p_articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "article_id,title,page_no,publication_id")] p_articles p_articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.publication_id = new SelectList(db.p_publication, "publication_id", "publication_id", p_articles.publication_id);
            return View(p_articles);
        }

        // GET: p_articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_articles p_articles = db.p_articles.Find(id);
            if (p_articles == null)
            {
                return HttpNotFound();
            }
            return View(p_articles);
        }

        // POST: p_articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_articles p_articles = db.p_articles.Find(id);
            db.p_articles.Remove(p_articles);
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
