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
    public class p_author_articlesController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_author_articles
        public ActionResult Index()
        {
            var p_author_articles = db.p_author_articles.Include(p => p.p_articles).Include(p => p.p_author);
            return View(p_author_articles.ToList());
        }

        // GET: p_author_articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author_articles p_author_articles = db.p_author_articles.Find(id);
            if (p_author_articles == null)
            {
                return HttpNotFound();
            }
            return View(p_author_articles);
        }

        // GET: p_author_articles/Create
        public ActionResult Create()
        {
            ViewBag.article_id = new SelectList(db.p_articles, "article_id", "title");
            ViewBag.author_id = new SelectList(db.p_author, "C_id", "lname");
            return View();
        }

        // POST: p_author_articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "author_id,article_id,C_id")] p_author_articles p_author_articles)
        {
            if (ModelState.IsValid)
            {
                db.p_author_articles.Add(p_author_articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.article_id = new SelectList(db.p_articles, "article_id", "title", p_author_articles.article_id);
            ViewBag.author_id = new SelectList(db.p_author, "C_id", "lname", p_author_articles.author_id);
            return View(p_author_articles);
        }

        // GET: p_author_articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author_articles p_author_articles = db.p_author_articles.Find(id);
            if (p_author_articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.article_id = new SelectList(db.p_articles, "article_id", "title", p_author_articles.article_id);
            ViewBag.author_id = new SelectList(db.p_author, "C_id", "lname", p_author_articles.author_id);
            return View(p_author_articles);
        }

        // POST: p_author_articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "author_id,article_id,C_id")] p_author_articles p_author_articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_author_articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.article_id = new SelectList(db.p_articles, "article_id", "title", p_author_articles.article_id);
            ViewBag.author_id = new SelectList(db.p_author, "C_id", "lname", p_author_articles.author_id);
            return View(p_author_articles);
        }

        // GET: p_author_articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author_articles p_author_articles = db.p_author_articles.Find(id);
            if (p_author_articles == null)
            {
                return HttpNotFound();
            }
            return View(p_author_articles);
        }

        // POST: p_author_articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_author_articles p_author_articles = db.p_author_articles.Find(id);
            db.p_author_articles.Remove(p_author_articles);
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
