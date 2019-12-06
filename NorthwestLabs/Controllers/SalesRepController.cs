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
            return View();
        }
        public ActionResult ViewCustomers()
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
            if (ModelState.IsValid)
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
}


    

