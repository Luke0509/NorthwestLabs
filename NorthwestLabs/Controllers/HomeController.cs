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

        public ActionResult Catalog()
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
            Customer newCust = new Customer();
            Employee newEmp = new Employee();
            newEmp = db.Employees.FirstOrDefault(x => x.Employee_Email == email);
            newCust = db.Customers.FirstOrDefault(x => x.Cust_Email == email);
            
            if (newEmp != null)
            {
                //it's an employee email
                if (newEmp.Employee_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    //authenticate

                    if (newEmp.Employee_Role_ID == 1)
                    {
                        return RedirectToAction("Index", "SalesRep");
                    }
                    else if (newEmp.Employee_Role_ID == 2)
                    {
                        return RedirectToAction("Index", "BR");
                    }
                    else if (newEmp.Employee_Role_ID == 3)
                    {
                        return RedirectToAction("Index", "SingaporeEmployee");
                    }
                    else if (newEmp.Employee_Role_ID == 4)
                    {
                        return RedirectToAction("Index", "TechDirector");
                    }
                    else if (newEmp.Employee_Role_ID == 5)
                    {
                        return RedirectToAction("Index", "SeattleEmployee");
                    }
                    else if (newEmp.Employee_Role_ID == 7)
                    {
                        return RedirectToAction("Index", "Manager");
                    }

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
            }

            return View();
        }

    }
}