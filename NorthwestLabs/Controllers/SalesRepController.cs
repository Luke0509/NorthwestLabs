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
            return View(db.Customers);
        }

        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create new customer";

            return View();
        }

        public ActionResult EditCustomer()
        {
            ViewBag.Message = "Edit Customer";
            
            /*
            var newCustomer = new Customer();
            newCustomer = db.Customers.Find(id);

            if (newCustomer != null)
            {
                db.Database.ExecuteSqlCommand(
                    "Update Customer_Information " +
                    "Set Customer_Information.Cust_ID = "  +
                    "Where Customer_Information.Cust_ID = " + id);

                return RedirectToAction("Index", "Home");
            }
            */

            return View();
        }

        public ActionResult RequestQuote()
        {
            ViewBag.Message = "Request quote from Singapore";

            return View();
        }
    }
}
