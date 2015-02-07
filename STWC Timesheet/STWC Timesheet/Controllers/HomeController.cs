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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

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

        private void CheckRegistration()
        {
            string serialKey = Registration.GenerateKey().ToString();
            ViewBag.SerialKey = serialKey;
            Key registration = db.Keys.SingleOrDefault();
            if (registration == null)
            {
                ViewBag.IsRegistered = false;
            }
            else
            {
                if (Key.ValidateKey(registration.SerialKey, registration.ActivationKey))
                {
                    ViewBag.IsRegistered = true;
                }
                else
                {
                    ViewBag.IsRegistered = false;
                }
            }
        }
    }
}
