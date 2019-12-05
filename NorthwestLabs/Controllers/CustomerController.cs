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
        private int custID = 0;
        private LabContext db = new LabContext();

        public ActionResult Index(Customer customer)
        {
            custID = customer.Cust_ID;
            return View();
        }
       

        public ActionResult MyOrders()
        {
            List<WorkOrders> lstWO = new List<WorkOrders>();
            ViewBag.Message = "Current Work Orders";
            foreach (WorkOrders workOrder in db.WorkOrders)
            {
                if (workOrder.Cust_ID == custID)
                {
                    lstWO.Add(workOrder);
                }
                    
            }
            return View(lstWO);
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