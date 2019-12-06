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
    public class TechDirectorController : Controller
    {
        private LabContext db = new LabContext();

        // GET: TechDirector
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
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
        public ActionResult EditWO([Bind(Include = "Order_ID, Cust_ID, Invoice_ID, Date_Created, Date_Completed, Order_Status, WO_Discount, Expedite_Order, Test2_IfActive, Test2_IfInactive, Analysis, Analysis_Completed")] WorkOrders wo)
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

            return View();
        }
    }
}