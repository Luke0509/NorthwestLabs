using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    
    public class ManagerController : Controller
    {
        private LabContext db = new LabContext();

        // GET: Manager
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult ViewSchedule()
        {
            ViewBag.Message = "Show list of test schedules. <br> have option to print out list";
            return View(db.Tests);
        }
        public ActionResult ChangeSchedule()
        {
            ViewBag.Message = "Change schedule to expedite a test";
            return View();
        }

        public ActionResult EditFinishDate()
        {
            ViewBag.Message = "Manager needs to be able to edit the end date of a test  to accomodate for the new expedited orders.";
            return View();
        }
    }
}