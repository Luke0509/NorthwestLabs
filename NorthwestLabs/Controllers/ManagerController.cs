using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            ViewBag.Message = "Show list of test schedules. <br> have option to print out list";
                               
            return View();
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