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
    public class p_transactionController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_transaction
        public ActionResult Index()
        {
            var p_transaction = db.p_transaction.Include(p => p.p_customer);
            return View(p_transaction.ToList());
        }

        // GET: p_transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_transaction p_transaction = db.p_transaction.Find(id);
            if (p_transaction == null)
            {
                return HttpNotFound();
            }
            return View(p_transaction);
        }

        // GET: p_transaction/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.p_customer, "cid", "fname");
            return View();
        }

        // POST: p_transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,total_price,discount_code,date,cid")] p_transaction p_transaction)
        {
            if (ModelState.IsValid)
            {
                db.p_transaction.Add(p_transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.p_customer, "cid", "fname", p_transaction.cid);
            return View(p_transaction);
        }

        // GET: p_transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_transaction p_transaction = db.p_transaction.Find(id);
            if (p_transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.p_customer, "cid", "fname", p_transaction.cid);
            return View(p_transaction);
        }

        // POST: p_transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,total_price,discount_code,date,cid")] p_transaction p_transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.p_customer, "cid", "fname", p_transaction.cid);
            return View(p_transaction);
        }

        // GET: p_transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_transaction p_transaction = db.p_transaction.Find(id);
            if (p_transaction.date < (DateTime.Today).AddDays(-30)) {
                ViewBag.ErrorMessage = "Cannot delete transaction as it is older than 30 days";
            }
            if (p_transaction == null)
            {
                return HttpNotFound();
            }
            return View(p_transaction);
        }

        // POST: p_transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_transaction p_transaction = db.p_transaction.Find(id);
            db.p_transaction.Remove(p_transaction);
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
