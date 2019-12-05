using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class BRController : Controller
    {
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            return View(db.Tests);
        }

        public ActionResult WorkOrders()
        {
       
            return View(db.WorkOrders); 
        }

        // Method to edit work order
        [HttpGet]
        public ActionResult EditWO(int id)
        {
            ViewBag.customers = db.Customers.ToList();
            ViewBag.employees = db.Employees.ToList();
            ViewBag.Message = "Edit Work Order";
            WorkOrders wo = db.WorkOrders.Find(id);
            return View(wo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWO([Bind(Include = "Order_ID, Cust_ID, Employee_ID, Invoice_ID, Date_Created, Date_Completed, WO_Discount, Expedite_Order, Test2_IfActive,  Test2_IfInactive, Results_File_Ascii, Analysis, Analysis_Completed")] WorkOrders wo)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.WorkOrders.Add(wo); 
                //edit entries
                db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkOrders");
            }

            return View(wo);
        }

        // Method to edit work order
        [HttpGet]
        public ActionResult CreateWO()
        {
            ViewBag.customers = db.Customers.ToList();
            ViewBag.employees = db.Employees.ToList();
            ViewBag.Message = "Edit Work Order";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWO([Bind(Include = "Order_ID, Cust_ID, Employee_ID, Date_Created, Date_Completed, WO_Discount, Expedite_Order, Test2_IfActive, Test2_IfInactive, Results_File_Ascii, Analysis, Analysis_Completed, Invoice_ID")] WorkOrders wo)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.WorkOrders.Add(wo); 
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkOrders");
            }

            return View(wo);
        }
    }
}
