using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class SalesRepController : Controller
    {
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create new customer";

            return View();
        }

        public ActionResult EditCustomer()
        {
            ViewBag.Message = "Edit Customer";

            return View();
        }

        public ActionResult RequestQuote()
        {
            ViewBag.Message = "Request quote from Singapore";

            return View();
        }
    }
}
