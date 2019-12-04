using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class SingaporeEmployeeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "List the test schedules.";
            return View();
        }

        public ActionResult CreateCompound()
        {
            return View();
        }

        public ActionResult EditWorkOrder()
        {
            return View();
        }

        public ActionResult ListWorkOrders()
        {
            ViewBag.Message = "List the work orders.";
            return View();
        }
    }
}