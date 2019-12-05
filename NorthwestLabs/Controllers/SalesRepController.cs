using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class SalesRepController : Controller
    {
        private int currentCustID = 0;
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            return View(db.Customers);
        }

        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create new customer";

            return View();
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            ViewBag.Message = "Edit Customer";
            currentCustID = id;
            return View(db.Customers.Find(id));
        }

        [HttpPost]
        public ActionResult EditCustomer(FormCollection form)
        {
            
            string custFirstName = form["First Name"].ToString();
            string custLastName = form["Last Name"].ToString();
            string streetAddress = form["Street Address"].ToString();
            string city = form["City"].ToString();
            string state = form["State"].ToString();
            string country = form["Country"].ToString();
            string zip = form["Zip"].ToString();
            string email = form["Email Address"].ToString();
            string password = form["Password"].ToString();
            string phoneNumber = form["Phone Number"].ToString();
            string dateCreated = form["Date of Account Creation"].ToString();
            double discount = Convert.ToDouble(form["Discount"]);

            db.Database.ExecuteSqlCommand(
            "UPDATE Customer_Information " +
            "Set Cust_First_Name = " + custFirstName + ", " +
                "Cust_Last_Name = " + custLastName + ", " +
                "Cust_Address = " + streetAddress + ", " +
                "Cust_City = " + city + ", " +
                "Cust_State = " + state + ", " +
                "Cust_Country = " + country + ", " +
                "Cust_Zip = " + zip + ", " +
                "Cust_Email = " + email + ", " +
                "Cust_Password = " + password + ", " +
                "Cust_Phone = " + phoneNumber + ", " +
                "Account_Created_Date = " + dateCreated + ", " +
                "Cust_Discount = " + discount +
            "Where Cust_ID = " + currentCustID);
           
            return View();
        }

        public ActionResult RequestQuote()
        {
            ViewBag.Message = "Request quote from Singapore";

            return View();
        }
    }
}
