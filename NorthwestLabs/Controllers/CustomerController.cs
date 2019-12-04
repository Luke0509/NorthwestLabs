using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class CustomerController : Controller
    {
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyOrders()
        {
            ViewBag.Message = "Current Work Orders";

            return View();
        }

        public ActionResult NewOrder()
        {
            ViewBag.Message = "New Work Order";

            return View();
        }

        public ActionResult PastOrders()
        {
            ViewBag.Message = "Past Work Order";

            return View();
        }
    }
}