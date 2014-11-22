using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STWC_Timesheet.Controllers
{
    public class ShipController : Controller
    {
        private stwcEntities db = new stwcEntities();

        //
        // GET: /Ship/

        public ActionResult Index()
        {
            return View(db.ships.ToList());
        }

        //
        // GET: /Ship/Details/5

        public ActionResult Details(int id = 0)
        {
            ship ship = db.ships.Single(s => s.ship_id == id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        //
        // GET: /Ship/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ship/Create

        [HttpPost]
        public ActionResult Create(ship ship)
        {
            if (ModelState.IsValid)
            {
                db.ships.AddObject(ship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ship);
        }

        //
        // GET: /Ship/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ship ship = db.ships.Single(s => s.ship_id == id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        //
        // POST: /Ship/Edit/5

        [HttpPost]
        public ActionResult Edit(ship ship)
        {
            if (ModelState.IsValid)
            {
                db.ships.Attach(ship);
                db.ObjectStateManager.ChangeObjectState(ship, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ship);
        }

        //
        // GET: /Ship/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ship ship = db.ships.Single(s => s.ship_id == id);
            if (ship == null)
            {
                return HttpNotFound();
            }
            return View(ship);
        }

        //
        // POST: /Ship/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ship ship = db.ships.Single(s => s.ship_id == id);
            db.ships.DeleteObject(ship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}