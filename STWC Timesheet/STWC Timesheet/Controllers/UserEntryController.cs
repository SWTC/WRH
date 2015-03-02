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

        public JsonResult LoadWorkedHours(int id, string currdate)
        {
            DateTime pDate = DateTime.ParseExact(currdate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime yesdate = pDate.AddDays(-1);
            Session["ssworkdate"] = pDate.ToString();
            var user_entry = (from ue in db.user_entry
                              where ue.user_id == id && (DateTime.Compare(ue.work_date.Value, yesdate) >= 0 && DateTime.Compare(ue.work_date.Value, pDate) <= 0)
                              select new { ue.entry_id, ue.user_id, ue.work_date, ue.hours_list, ue.total_hours, ue.comments, ue.nc_remarks }).OrderBy(x => x.work_date).ToList();

            return Json(user_entry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadNCDates(int id, int monthNum)
        {
            var user_entry = (from ue in db.user_entry
                              where ue.user_id == id && ue.work_date.Value.Month == monthNum && ue.nc_remarks != null
                              select new { ue.work_date }).ToList();

            return Json(user_entry, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /UserEntry/Edit/5

        [HttpPost]
        public ActionResult Edit(user_entry user_entry)
        {
            if (user_entry.entry_id == 0)
            {
                if(user_entry.work_date == null)
                {
                    user_entry.work_date = Convert.ToDateTime(this.Session["ssworkdate"]);
                }
                db.user_entry.AddObject(user_entry);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = user_entry.entry_id });
            }
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

        //Reports

        public ActionResult Reports()
        {
            if (Convert.ToInt32(Session["RankId"]) == 1)
            {
                var crewlist = (from c in db.users
                                where c.rank_id != 1
                                select new { value = c.user_id, text = c.firstname + " " + c.lastname }).ToList();
                ViewBag.crew_list = new SelectList(crewlist, "value", "text");
            }
            else
            {
                int uid = Convert.ToInt32(Session["UserId"]);
                var crewlist = (from c in db.users
                                where c.user_id == uid
                                select new { value = c.user_id, text = c.firstname + " " + c.lastname }).ToList();
                ViewBag.crew_list = new SelectList(crewlist, "value", "text");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Reports(user_entry model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public JsonResult GenerateReportHeader(int Userid)
        {
            var entry = (from u in db.users
                         join r in db.ranks on u.rank_id equals r.rank_id
                         join s in db.ships on u.ship_id equals s.ship_id
                         where u.user_id == Userid
                         select new { firstname = u.firstname, lastname = u.lastname, rankname = r.rank_name, shipname = s.ship_name, imonumber = s.ship_IMO, flag = s.flag }).FirstOrDefault();

            return Json(entry, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GenerateReport(int Userid, DateTime fromDate, DateTime toDate)
        {
            var entry = (from ue in db.user_entry
                                      where ue.user_id == Userid && ue.work_date >= fromDate && ue.work_date <= toDate
                              select new { ue.work_date, ue.hours_list, ue.total_hours }).OrderBy(x => x.work_date).ToList();

            return Json(entry, JsonRequestBehavior.AllowGet);
        }
    }
}