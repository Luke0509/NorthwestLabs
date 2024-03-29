﻿using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    //This controller controls all of the tech director views, including analyzing results
    [Authorize]
    public class TechDirectorController : Controller
    {
        private LabContext db = new LabContext();

        public static List<OrderStatus> lstStatus = new List<OrderStatus>();

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
        public ActionResult EditWO([Bind(Include = "Order_ID, Cust_ID, Date_Created, Date_Completed, Order_Status, WO_Discount, Expedite_Order, Test2_IfActive, Test2_IfInactive, Analysis, Analysis_Completed")] WorkOrders wo)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.WorkOrders.Add(wo); 
                //edit entries
                db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewOrders");
            }

            return View(wo);
        }

        [HttpGet]
        public ActionResult AnalyzeWO(int id)
        {
            var entry = db.Order_Details.Where(p => p.Order_ID == id).ToList();
            ViewBag.entries = entry;
            ViewBag.idNum = id;
            return View();
        }
    }
}