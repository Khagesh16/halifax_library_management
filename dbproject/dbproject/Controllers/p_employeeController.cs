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
    public class p_employeeController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_employee
        public ActionResult Index()
        {
            return View(db.p_employee.ToList());
        }

        // GET: p_employee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_employee p_employee = db.p_employee.Find(id);
            if (p_employee == null)
            {
                return HttpNotFound();
            }
            return View(p_employee);
        }

        // GET: p_employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sin,fname,lname,hourly_pay")] p_employee p_employee)
        {
            if (ModelState.IsValid)
            {
                db.p_employee.Add(p_employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p_employee);
        }

        // GET: p_employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_employee p_employee = db.p_employee.Find(id);
            if (p_employee == null)
            {
                return HttpNotFound();
            }
            return View(p_employee);
        }

        // POST: p_employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sin,fname,lname,hourly_pay")] p_employee p_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p_employee);
        }

        // GET: p_employee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_employee p_employee = db.p_employee.Find(id);
            if (p_employee == null)
            {
                return HttpNotFound();
            }
            return View(p_employee);
        }

        // POST: p_employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            p_employee p_employee = db.p_employee.Find(id);
            db.p_employee.Remove(p_employee);
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
