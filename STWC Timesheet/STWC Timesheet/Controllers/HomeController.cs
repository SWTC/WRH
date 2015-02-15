using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STWC_Timesheet.Models;

namespace STWC_Timesheet.Controllers
{
    public class HomeController : Controller
    {
        private stwcEntities db = new stwcEntities();

        public ActionResult Index()
        {
            CheckRegistration();
            ViewBag.Message = "";

            return View();
        }

        [HttpPost]
        public ActionResult Index(string post)
        {
            if (Request.Params["SerialKey"] != null && Request.Params["ActivationKey"] != null)
            {
                string regKey = Request.Params["ActivationKey"].ToString();
                if (Registration.ValidateRegistration(regKey))
                {
                    Key actKey = new Key();
                    actKey.SerialKey = Request.Params["SerialKey"].ToString();
                    actKey.ActivationKey = Request.Params["ActivationKey"].ToString();
                    db.Keys.AddObject(actKey);
                    db.SaveChanges();

                    ship serShip = new ship();
                    serShip.serial_number = Request.Params["SerialKey"].ToString();
                    db.ships.AddObject(serShip);
                    db.SaveChanges();

                    user adm = new user();
                    adm.firstname = "Admin";
                    adm.lastname = "Admin";
                    adm.user_name = "admin";
                    adm.password = "P@ssw0rd";
                    adm.ship_id = serShip.ship_id;
                    adm.rank_id = 1;
                    db.users.AddObject(adm);
                    db.SaveChanges();

                    return RedirectToAction("Login", "Account");
                }
                ViewBag.Error = "Invalid Activation Key. Please contact the administartor";
            }
            CheckRegistration();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        private ActionResult CheckRegistration()
        {
            string serialKey = Registration.GenerateKey().ToString();
            //ViewBag.IsRegistered = false;
            ViewBag.SerialKey = serialKey;
            Key registration = db.Keys.SingleOrDefault();
            if (registration == null)
            {
                TempData["IsRegistered"] = false;
            }
            else
            {
                if (Key.ValidateKey(registration.SerialKey, registration.ActivationKey))
                {
                    TempData["IsRegistered"] = true;
                }
                else
                {
                    TempData["IsRegistered"] = false;
                }
            }
            return View();
        }
    }
}
