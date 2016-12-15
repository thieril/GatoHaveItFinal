using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GatoHaveItFinal.Models;
//using GatoHaveItFinal.Repository;


namespace GatoHaveItFinal.Controllers
{
    public class MerchandisesController : Controller
    {
        private DataModel db = new DataModel();


        public ActionResult Index()
        {
            //var merch = db.Merchandises.ToList();
            return View(db.Merchandises.ToList());
        }
       
        

        //public ActionResult Browse(string merchandise)
        //{
        //    //retrive genre and its associated albumns from data base
        //    //within genre data set we want to include albums
        //    var merchandiseModel = db //using ;inq and Lambda expression
        //        //.Merchandise.Include("Albums") // makes it more efficient eause we will retrieve all associated alums that match genre
        //        .Single(g => g.ProductId == id // genre is what we are passing in

        //    return View(merchandiseModel);
        //}

            

        //// GET: Merchandises

        //public ActionResult Index(int? id)
        //{
        //    if (id != null)
        //    {
        //        // query for category with id
        //        //return View(db.Merchandises.ToList(id));

        //        Merchandise merchandise = db.Merchandises

        //      .SingleOrDefault(x => x.ProductId == id);
        //        return View();
        //    }
        //    else {
        //        return View(db.Merchandises.ToList());
        //    }
        //}





        //public ActionResult TshirtQuery()
        //{

        //    return View(db.Merchandises.ToList());
        //}

        //public ActionResult MerchandiseList(id)
        //{

        //    var merchandiseList = 
        //    return View(MerchandiseList);
        //}






        //public ActionResult Tshirts()
        //{
        //    TshirtRespository TshirtRepo = new TshirtRespository(); //creating instance of repository
        //    ModelState.Clear();  //this creates a dictionary object that contains state of the model

        //    return View(TshirtRepo.Tshirts()); //return to view method created in album repository to get all albums
        //}



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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
