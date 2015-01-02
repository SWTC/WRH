﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STWC_Timesheet.Controllers
{
    public class UserEntryController : Controller
    {
        private stwcEntities db = new stwcEntities();

        //
        // GET: /UserEntry/

        [Authorize]
        public ActionResult Index()
        {
            return View(db.user_entry.ToList());
        }

        //
        // GET: /UserEntry/Details/5

        public ActionResult Details(int id = 0)
        {
            user_entry user_entry = db.user_entry.Single(u => u.entry_id == id);
            if (user_entry == null)
            {
                return HttpNotFound();
            }
            return View(user_entry);
        }

        //
        // GET: /UserEntry/Create

        public ActionResult Create()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            DateTime curdate = DateTime.Today;
            DateTime yesdate = DateTime.Today.AddDays(-1);
            DateTime tomdate = DateTime.Today.AddDays(1);
            var user_entry = (from ue in db.user_entry
                              where ue.user_id == userid && ue.work_date == curdate
                               select ue).FirstOrDefault();
            if (user_entry != null)
            {
                return RedirectToAction("Edit", new { id = user_entry.entry_id });
            }
            return View();
        }

        //
        // POST: /UserEntry/Create

        [HttpPost]
        public ActionResult Create(user_entry user_entry)
        {
            if (ModelState.IsValid)
            {
                db.user_entry.AddObject(user_entry);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = user_entry.entry_id });
            }

            return View(user_entry);
        }

        //
        // GET: /UserEntry/Edit/5

        public ActionResult Edit(int id = 0)
        {
            user_entry user_entry = db.user_entry.Single(u => u.entry_id == id);
            if (user_entry == null)
            {
                return HttpNotFound();
            }
            return View(user_entry);
        }

        public ActionResult LoadWorkHours(int id, DateTime currdate)
        {
            var user_entry = (from ue in db.user_entry
                              where ue.user_id == id && ue.work_date == currdate
                              select ue).FirstOrDefault();
            if (user_entry != null)
            {
                return RedirectToAction("Edit", new { id = user_entry.entry_id });
            }
            return View();
        }

        //
        // POST: /UserEntry/Edit/5

        [HttpPost]
        public ActionResult Edit(user_entry user_entry)
        {
            if (ModelState.IsValid)
            {
                db.user_entry.Attach(user_entry);
                db.ObjectStateManager.ChangeObjectState(user_entry, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = user_entry.entry_id });
            }
            return View(user_entry);
        }

        //
        // GET: /UserEntry/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user_entry user_entry = db.user_entry.Single(u => u.entry_id == id);
            if (user_entry == null)
            {
                return HttpNotFound();
            }
            return View(user_entry);
        }

        //
        // POST: /UserEntry/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user_entry user_entry = db.user_entry.Single(u => u.entry_id == id);
            db.user_entry.DeleteObject(user_entry);
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