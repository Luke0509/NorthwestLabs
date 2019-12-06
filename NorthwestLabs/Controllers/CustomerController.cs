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
        private static int currentCustID;
        private LabContext db = new LabContext();


        public ActionResult Index(Customer customer)
        {
            currentCustID = customer.Cust_ID;
            return View();
        }
       

        public ActionResult MyOrders()
        {   
            List<WorkOrders> lstWO = new List<WorkOrders>();
            Customer currCust = db.Customers.Find(currentCustID);
            ViewBag.Message = "Work Orders for " + currCust.Cust_First_Name + " " + currCust.Cust_Last_Name;
            foreach (WorkOrders workOrder in db.WorkOrders)
            {
                if (workOrder.Cust_ID == currentCustID)
                {
                    lstWO.Add(workOrder);
                }
                    
            }
            return View(lstWO);
        }

        public ActionResult CreateOrder()
        {
            ViewBag.Message = "New Work Order";

            return View();
        }

        public ActionResult OrderProgress(int? id)
        {

            return View(db.WorkOrders.Find(id));
        }

    }
}