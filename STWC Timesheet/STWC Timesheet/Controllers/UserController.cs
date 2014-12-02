using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using STWC_Timesheet.Models;

namespace STWC_Timesheet.Controllers
{
    public class UserController : Controller
    {
        private stwcEntities db = new stwcEntities();

        //
        // GET: /User/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var users = GetFormattedData(searchString, currentFilter, sortOrder, page);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
            //return View(db.users.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            user user = db.users.Single(u => u.user_id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                db.users.AddObject(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            user user = db.users.Single(u => u.user_id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Attach(user);
                db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user user = db.users.Single(u => u.user_id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Single(u => u.user_id == id);
            db.users.DeleteObject(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private IQueryable<user> GetFormattedData(string searchString, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ViewBag.UserIDSortParm = String.IsNullOrEmpty(sortOrder) ? "UI_desc" : "";
            ViewBag.RankIDSortParm = sortOrder == "RI_desc" ? "RI_desc" : "RI_asc";
            ViewBag.FirstNameSortParm = sortOrder == "FN_desc" ? "FN_desc" : "FN_asc";
            ViewBag.LastNameSortParm = sortOrder == "LN_desc" ? "LN_desc" : "LN_asc";
            ViewBag.EmailSortParm = sortOrder == "Email_desc" ? "Email_desc" : "Email_asc";
            ViewBag.Signon_DateSortParm = sortOrder == "SND_desc" ? "SND_desc" : "SND_asc";
            ViewBag.Signoff_DateSortParm = sortOrder == "SOD_desc" ? "SOD_desc" : "SOD_asc";
            ViewBag.UserNameSortParm = sortOrder == "UN_desc" ? "UN_desc" : "UN_asc";

            var users = from u in db.users
                         select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.firstname.ToUpper().Contains(searchString.ToUpper())
                                       || s.lastname.ToUpper().Contains(searchString.ToUpper())
                                       || s.email.ToUpper().Contains(searchString.ToUpper())
                                       || s.user_name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "UI_desc":
                    users = users.OrderByDescending(s => s.user_id);
                    break;
                case "RI_desc":
                    users = users.OrderByDescending(s => s.rankid);
                    ViewBag.LoanOfficerSortParm = "RI_asc";
                    break;
                case "RI_asc":
                    users = users.OrderBy(s => s.rankid);
                    ViewBag.LoanOfficerSortParm = "RI_desc";
                    break;
                case "FN_desc":
                    users = users.OrderByDescending(s => s.firstname);
                    ViewBag.LOASortParm = "FN_asc";
                    break;
                case "FN_asc":
                    users = users.OrderBy(s => s.firstname);
                    ViewBag.LOASortParm = "FN_desc";
                    break;
                case "LN_desc":
                    users = users.OrderByDescending(s => s.lastname);
                    ViewBag.TranscationCoordinatorSortParm = "LN_asc";
                    break;
                case "LN_asc":
                    users = users.OrderBy(s => s.lastname);
                    ViewBag.TranscationCoordinatorSortParm = "LN_desc";
                    break;
                case "Email_desc":
                    users = users.OrderByDescending(s => s.email);
                    ViewBag.Borrower_EmailSortParm = "Email_asc";
                    break;
                case "Email_asc":
                    users = users.OrderBy(s => s.email);
                    ViewBag.Borrower_EmailSortParm = "Email_desc";
                    break;
                case "SND_desc":
                    users = users.OrderByDescending(s => s.signon_date);
                    ViewBag.Borrower_First_NameSortParm = "SND_asc";
                    break;
                case "SND_asc":
                    users = users.OrderBy(s => s.signon_date);
                    ViewBag.Borrower_First_NameSortParm = "SND_desc";
                    break;
                case "SOD_desc":
                    users = users.OrderByDescending(s => s.signoff_date);
                    ViewBag.Borrower_Last_NameSortParm = "SOD_asc";
                    break;
                case "SOD_asc":
                    users = users.OrderBy(s => s.signoff_date);
                    ViewBag.Borrower_Last_NameSortParm = "SOD_desc";
                    break;
                case "UN_desc":
                    users = users.OrderByDescending(s => s.user_name);
                    ViewBag.StatusSortParm = "UN_asc";
                    break;
                case "UN_asc":
                    users = users.OrderBy(s => s.user_name);
                    ViewBag.StatusSortParm = "UN_desc";
                    break;
                default:
                    users = users.OrderBy(s => s.user_id);
                    break;
            }
            return users;
        }
    }
}