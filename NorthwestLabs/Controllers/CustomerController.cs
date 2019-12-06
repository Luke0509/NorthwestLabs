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
        [HttpGet]
        public ActionResult CreateOrder()
        {
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder([Bind(Include = "Order_ID, Cust_ID, Date_Created, Expedite_Order, Test2_IfActive, Test2_IfInactive, Analysis_Completed")] WorkOrders wo)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.WorkOrders.Add(wo);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyOrders");
            }

            return View(wo);
        }

        public ActionResult AddCompound(int? id)
        {
            List<WorkOrders> lstorders = new List<WorkOrders>();
            lstorders.Add(db.WorkOrders.Find(id));
            ViewBag.Assays = db.Assays.ToList();
            ViewBag.Orders = lstorders;
            return View();
        }
        [HttpPost]
        public ActionResult AddCompound([Bind(Include = "LT_Number, Assay_ID, Order_ID, Date_Arrived, Date_Due, Compound_Weight_Client, Compound_Appearance, Molecular_Mass")] Compound_Samples cs)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Compound_Samples.Add(cs);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyOrders");
            }

            return View(cs);
        }

        public ActionResult OrderProgress(int? id)
        {

            return View(db.WorkOrders.Find(id));
        }

        public ActionResult RequestQuote()
        {
            return View();
        }

    }
}