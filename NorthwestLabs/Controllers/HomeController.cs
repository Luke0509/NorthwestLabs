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
        private Customer currentCust = new Customer();
        private Employee currentEmployee = new Employee();


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
            //Customer currentCust = new Customer();
            //Employee currentEmp = new Employee();
            currentCust = db.Customers.FirstOrDefault(x => x.Cust_Email == email);
            currentEmployee = db.Employees.FirstOrDefault(x => x.Employee_Email == email);
            if (currentEmployee != null)
            {
                //it's an employee email
                if (currentEmployeeloyee.Employee_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    //authenticate

                    if (currentEmployee.Employee_Role_ID == 1)
                    {
                        return RedirectToAction("Index", "SalesRep");
                    }
                    else if (currentEmployee.Employee_Role_ID == 2)
                    {
                        return RedirectToAction("Index", "BR");
                    }
                    else if (currentEmployee.Employee_Role_ID == 3)
                    {
                        return RedirectToAction("Index", "SingaporeEmployee");
                    }
                    else if (currentEmployee.Employee_Role_ID == 4)
                    {
                        return RedirectToAction("Index", "TechDirector");
                    }
                    else if (currentEmployee.Employee_Role_ID == 5)
                    {
                        return RedirectToAction("Index", "SeattleEmployee");
                    }
                    else if (currentEmployee.Employee_Role_ID == 7)
                    {
                        return RedirectToAction("Index", "Manager");
                    }

                }
                else
                {
                    ViewBag.PasswordMessage = "Password is incorrect";
                }

            }
            else if (currentCust != null)
            {
                //it's a customer email
                if (currentCust.Cust_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    return RedirectToAction("Index", "Customer");
                    //authenticate
                }
                else
                {
                    ViewBag.PasswordMessage = "Password is incorrect";
                }
            }
            else
            {
                ViewBag.PasswordMessage = "There is no account associated with that Email address. Please try another Email.";

                return View();
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Home");
        }
    }

}