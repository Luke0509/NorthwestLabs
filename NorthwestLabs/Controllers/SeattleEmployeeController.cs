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
    public class SeattleEmployeeController : Controller
    {
        private LabContext db = new LabContext();
        public static List<OrderStatus> lstStatus = new List<OrderStatus>();
        // GET: SeattleEmployee
        public ActionResult Index()
        {
            return View();
        }
        // Method to edit work order

        public ActionResult ViewWorkOrders()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditWO(int id)
        {
            //add list of order statuses 
            lstStatus.Clear();
            OrderStatus received = new OrderStatus();
            received.Status_ID = 1;
            received.Status_Description = "Received";
            lstStatus.Add(received);
            OrderStatus testing = new OrderStatus();
            testing.Status_ID = 2;
            testing.Status_Description = "Testing";
            lstStatus.Add(testing);
            OrderStatus finalizingReport = new OrderStatus();
            finalizingReport.Status_ID = 3;
            finalizingReport.Status_Description = "Finalizing Reports";
            lstStatus.Add(finalizingReport);
            OrderStatus finished = new OrderStatus();
            finished.Status_ID = 4;
            finished.Status_Description = "Finished";
            lstStatus.Add(finished);
            //add list to viewbag
            ViewBag.orderStatus = lstStatus;

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

            return View(wo);
        }

        // Method to edit work order
        [HttpGet]
        public ActionResult CreateWO()
        {
            //add list of order statuses 
            lstStatus.Clear();
            OrderStatus received = new OrderStatus();
            received.Status_ID = 1;
            received.Status_Description = "Received";
            lstStatus.Add(received);
            OrderStatus testing = new OrderStatus();
            testing.Status_ID = 2;
            testing.Status_Description = "Testing";
            lstStatus.Add(testing);
            OrderStatus finalizingReport = new OrderStatus();
            finalizingReport.Status_ID = 3;
            finalizingReport.Status_Description = "Finalizing Reports";
            lstStatus.Add(finalizingReport);
            OrderStatus finished = new OrderStatus();
            finished.Status_ID = 4;
            finished.Status_Description = "Finished";
            lstStatus.Add(finished);
            //add list to viewbag
            ViewBag.orderStatus = lstStatus;

            ViewBag.customers = db.Customers.ToList();
            ViewBag.employees = db.Employees.ToList();
            ViewBag.Message = "Edit Work Order";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWO([Bind(Include = "Order_ID, Cust_ID, Invoice_ID, Date_Created, Date_Completed, Order_Status, WO_Discount, Expedite_Order, Test2_IfActive, Test2_IfInactive, Analysis, Analysis_Completed")] WorkOrders wo)
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

        [HttpGet]
        public ActionResult ChooseCatalog()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PharmaCatalog()
        {
            return View(db.Assays);
        }

        [HttpGet]
        public ActionResult ProtoNotebook()
        {
            return View(db.Assays);
        }

        [HttpGet]
        public ActionResult EditAssay(int id)
        {
            ViewBag.compounds = db.Compounds.ToList();
            Assay assay = db.Assays.Find(id);
            return View(assay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAssay([Bind(Include = "Assay_ID,Compound_ID,Assay_Duration,No_Of_Tests,Assay_Price,Assay_Name,Assay_Summary,Assay_Details")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.WorkOrders.Add(wo); 
                //edit entries
                db.Entry(assay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PharmaCatalog");
            }
            return View(assay);
        }

        [HttpGet]
        public ActionResult CreateAssay()
        {
            ViewBag.compounds = db.Compounds.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAssay([Bind(Include = "Assay_ID,Compound_ID,Assay_Duration,No_Of_Tests,Assay_Price,Assay_Name,Assay_Summary,Assay_Details")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Assays.Add(assay);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChooseCatalog");
            }

            return View(assay);
        }

        public ActionResult DeleteAssay(int id)
        {
            Assay assay = db.Assays.Find(id);
            if (assay != null)
            {
                db.Assays.Remove(assay);
                db.SaveChanges();
                return RedirectToAction("ChooseCatalog");
            }
            return RedirectToAction("ChooseCatalog");
        }
    }
}