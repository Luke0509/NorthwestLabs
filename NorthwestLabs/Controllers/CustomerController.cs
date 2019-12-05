using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private LabContext db = new LabContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult MyOrders(int? id)
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