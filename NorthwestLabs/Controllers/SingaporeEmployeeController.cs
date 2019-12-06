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
    public class SingaporeEmployeeController : Controller
    {
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            ViewBag.Message = "List the test schedules.";
            return View(db.Compound_Samples);
        }

        // Method to create work order
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CompoundSamples = db.Compound_Samples.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LT_Number, Assay_ID, Order_ID, Date_Arrived, Date_Processed, Date_Due, Compound_Weight_Client, Actual_Weight, Molecular_Mass")] Compound_Samples cs)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Compound_Samples.Add(cs);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CreateOrderDetail");
            }

            ViewBag.Message = "Error in validation";
            return View(cs);
        }

        // Method to edit work order
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CompoundSamples = db.Compound_Samples.ToList();
            Compound_Samples cs = db.Compound_Samples.Find(id);
            return View(cs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LT_Number, Assay_ID, Order_ID, Date_Arrived, Date_Processed, Date_Due, Compound_Weight_Client, Actual_Weight, Molecular_Mass")] Compound_Samples cs)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.Compound_Samples.Add(cs);
                //edit entries
                db.Entry(cs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Error in validation";
            return View(cs);
        }


        // Method to create work order
        [HttpGet]
        public ActionResult CreateOrderDetail()
        {
            ViewBag.OrderDetails = db.Order_Details.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderDetail([Bind(Include = "Order_ID, LT_Number, Item_Price, Results_File_Ascii")] Order_Details od)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Order_Details.Add(od);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(); 

        }
    }
}