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
    public class HomeController : Controller
    {
        // GET: Home
        private LabContext db = new LabContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();
            var newCust = new Customer();
            var newEmp = new Employee();
            newCust = db.Customers.FirstOrDefault(x => x.Cust_Email == email);
            newEmp = db.Employees.FirstOrDefault(x => x.Employee_Email == email);
            if (newEmp != null)
            {
                //it's an employee email
                if (newEmp.Employee_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    //authenticate
                }
                else
                {
                    ViewBag.PasswordMessage = "Password is incorrect";
                }

            }
            else if (newCust != null)
            {
                //it's a customer email
                if (newCust.Cust_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    //authenticate
                }
                else
                {
                    ViewBag.PasswordMessage = "Password is incorrect";
                }
            }
            else
            {
                ViewBag.PasswordMessage = "There is no account with that Email address. Please try another Email."
            }
            return View();
            }

    }
}