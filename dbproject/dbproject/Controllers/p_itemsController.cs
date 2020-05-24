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
    public class p_itemsController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_items
        public ActionResult Index()
        {
            return View(db.p_items.ToList());
        }

        // GET: p_items/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_items p_items = db.p_items.Find(id);
            if (p_items == null)
            {
                return HttpNotFound();
            }
            return View(p_items);
        }

        // GET: p_items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id,price")] p_items p_items)
        {
            if (ModelState.IsValid)
            {
                db.p_items.Add(p_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_items);
        }

        // GET: p_items/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_items p_items = db.p_items.Find(id);
            if (p_items == null)
            {
                return HttpNotFound();
            }
            return View(p_items);
        }

        // POST: p_items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id,price")] p_items p_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_items);
        }

        // GET: p_items/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_items p_items = db.p_items.Find(id);
            if (p_items == null)
            {
                return HttpNotFound();
            }
            return View(p_items);
        }

        // POST: p_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            p_items p_items = db.p_items.Find(id);
            db.p_items.Remove(p_items);
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
