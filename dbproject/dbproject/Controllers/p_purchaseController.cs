using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace dbproject.Controllers
{
    public class p_purchaseController : Controller
    {
        private dbfinalprojectEntities db = new dbfinalprojectEntities();

        // GET: p_purchase
        public ActionResult Index()
        {
            IQueryable<p_purchase> p_purchase = db.p_purchase.Include(p => p.p_items).Include(p => p.p_transaction);
            return View(p_purchase.ToList());
        }

        // GET: p_purchase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_purchase p_purchase = db.p_purchase.Find(id);
            if (p_purchase == null)
            {
                return HttpNotFound();
            }
            return View(p_purchase);
        }

        // GET: p_purchase/Create
        public ActionResult Create()
        {
            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id");
            ViewBag.transaction_id = new SelectList(db.p_transaction, "transaction_id", "transaction_id");
            return View();
        }

        public ActionResult CreateWithTransaction(int id)
        {
            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id");
            ViewBag.transaction_id = id;
            return View();
        }

        // POST: p_purchase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "transaction_id,item_id,C_id")] p_purchase p_purchase)
        {
            if (ModelState.IsValid)
            {
                db.p_purchase.Add(p_purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id", p_purchase.item_id);
            ViewBag.transaction_id = new SelectList(db.p_transaction, "transaction_id", "transaction_id", p_purchase.transaction_id);
            return View(p_purchase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithTransaction([Bind(Include = "transaction_id,item_id,C_id")] p_purchase p_purchase)
        {
            if (ModelState.IsValid)
            {
                db.p_purchase.Add(p_purchase);
                db.SaveChanges();
                return RedirectToAction("Details", "p_transaction", new { id = p_purchase.transaction_id });
            }

            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id", p_purchase.item_id);
            ViewBag.transaction_id = new SelectList(db.p_transaction, "transaction_id", "transaction_id", p_purchase.transaction_id);
            return View(p_purchase);
        }
        // GET: p_purchase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_purchase p_purchase = db.p_purchase.Find(id);
            if (p_purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id", p_purchase.item_id);
            ViewBag.transaction_id = new SelectList(db.p_transaction, "transaction_id", "transaction_id", p_purchase.transaction_id);
            return View(p_purchase);
        }

        // POST: p_purchase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transaction_id,item_id,C_id")] p_purchase p_purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.item_id = new SelectList(db.p_items, "C_id", "C_id", p_purchase.item_id);
            ViewBag.transaction_id = new SelectList(db.p_transaction, "transaction_id", "transaction_id", p_purchase.transaction_id);
            return View(p_purchase);
        }

        // GET: p_purchase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_purchase p_purchase = db.p_purchase.Find(id);
            if (p_purchase == null)
            {
                return HttpNotFound();
            }
            return View(p_purchase);
        }

        // POST: p_purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_purchase p_purchase = db.p_purchase.Find(id);
            var tid = p_purchase.transaction_id;
            db.p_purchase.Remove(p_purchase);
            db.SaveChanges();
            return RedirectToAction("Details", "p_transaction", new { id = tid });
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
