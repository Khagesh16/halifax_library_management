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
    public class p_authorController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_author
        public ActionResult Index()
        {
            return View(db.p_author.ToList());
        }

        // GET: p_author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author p_author = db.p_author.Find(id);
            if (p_author == null)
            {
                return HttpNotFound();
            }
            return View(p_author);
        }

        // GET: p_author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id,lname,fname,email")] p_author p_author)
        {
            if (ModelState.IsValid && !db.p_author.Where(item => item.fname == p_author.fname && item.lname == p_author.lname).Any())
            {
                db.p_author.Add(p_author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "This user already exists";
            return View(p_author);
        }

        // GET: p_author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author p_author = db.p_author.Find(id);
            if (p_author == null)
            {
                return HttpNotFound();
            }
            return View(p_author);
        }

        // POST: p_author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id,lname,fname,email")] p_author p_author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_author);
        }

        // GET: p_author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_author p_author = db.p_author.Find(id);
            if (p_author == null)
            {
                return HttpNotFound();
            }
            return View(p_author);
        }

        // POST: p_author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_author p_author = db.p_author.Find(id);
            db.p_author.Remove(p_author);
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
