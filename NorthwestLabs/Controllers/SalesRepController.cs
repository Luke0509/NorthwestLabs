using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System.Data.Entity;
using System.Net;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class SalesRepController : Controller
    {
        private LabContext db = new LabContext();

        public static List<OrderStatus> lstStatus = new List<OrderStatus>();

        public ActionResult Index()
        {
            return View(db.Customers);
        }

        [HttpGet]
        public ActionResult CreateCustomer(int id)
        {
            ViewBag.Message = "Create Customer";
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer([Bind(Include = "Cust_ID, Cust_First_Name, Cust_Last_Name, Cust_Address, Cust_City, Cust_State, Cust_Country, Cust_Zip, Cust_Email, Cust_Password, Cust_Phone, Account_Created_Date, Cust_Discount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Customers.Add(customer); 
                //edit entries
                //db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            ViewBag.Message = "Edit Customer";
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "Cust_ID, Cust_First_Name, Cust_Last_Name, Cust_Address, Cust_City, Cust_State, Cust_Country, Cust_Zip, Cust_Email, Cust_Password, Cust_Phone, Account_Created_Date, Cust_Discount")] Customer customer)
        {
            if(ModelState.IsValid)
            {
                //add entry
                // db.Customers.Add(customer); 
                //edit entries
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                                                  
            return View(customer);
        }

        public ActionResult RequestQuote()
        {
            ViewBag.Message = "Request quote from Singapore";

            return View();
        }

        public ActionResult ViewCosts()
        {
            ViewBag.Message = "Costs of Current Tests";
            return View(db.Invoices); 
        }
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
}
}
}
