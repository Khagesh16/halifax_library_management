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
    public class p_customerController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_customer
        public ActionResult Index()
        {
            return View(db.p_customer.ToList());
        }

        // GET: p_customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_customer p_customer = db.p_customer.Find(id);
            if (p_customer == null)
            {
                return HttpNotFound();
            }
            return View(p_customer);
        }

        // GET: p_customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cid,fname,lname,telephone,streetNo,street_name,apt_no,zipcode")] p_customer p_customer)
        {
            if (ModelState.IsValid && !db.p_customer.Where(x => x.fname == p_customer.fname && x.lname == p_customer.lname).Any())
            {
                db.p_customer.Add(p_customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Customer already Exists";
            return View(p_customer);
        }

        // GET: p_customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_customer p_customer = db.p_customer.Find(id);
            if (p_customer == null)
            {
                return HttpNotFound();
            }
            return View(p_customer);
        }

        // POST: p_customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cid,fname,lname,telephone,streetNo,street_name,apt_no,zipcode")] p_customer p_customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_customer);
        }

        // GET: p_customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_customer p_customer = db.p_customer.Find(id);
            if (p_customer == null)
            {
                return HttpNotFound();
            }
            return View(p_customer);
        }

        // POST: p_customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_customer p_customer = db.p_customer.Find(id);
            db.p_customer.Remove(p_customer);
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
