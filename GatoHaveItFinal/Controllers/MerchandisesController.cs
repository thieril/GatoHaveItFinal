using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GatoHaveItFinal.Models;

namespace GatoHaveItFinal.Controllers
{
    public class MerchandisesController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Merchandises
        public ActionResult Index()
        {
            return View(db.Merchandises.ToList());
        }

        // GET: Merchandises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchandise merchandise = db.Merchandises.Find(id);
            if (merchandise == null)
            {
                return HttpNotFound();
            }
            return View(merchandise);
        }

        // GET: Merchandises/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Merchandises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Description,UnitPrice,Image")] Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                db.Merchandises.Add(merchandise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(merchandise);
        }

        // GET: Merchandises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchandise merchandise = db.Merchandises.Find(id);
            if (merchandise == null)
            {
                return HttpNotFound();
            }
            return View(merchandise);
        }

        // POST: Merchandises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Description,UnitPrice,Image")] Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchandise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }

        // GET: Merchandises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchandise merchandise = db.Merchandises.Find(id);
            if (merchandise == null)
            {
                return HttpNotFound();
            }
            return View(merchandise);
        }

        // POST: Merchandises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Merchandise merchandise = db.Merchandises.Find(id);
            db.Merchandises.Remove(merchandise);
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
