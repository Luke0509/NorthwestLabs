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
            currentCust = db.Customers.FirstOrDefault(x => x.Cust_Email == email);
            currentEmployee = db.Employees.FirstOrDefault(x => x.Employee_Email == email);
            if (currentEmployee != null)
            {
                //it's an employee email
                if (currentEmployee.Employee_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    //authenticate

                    if (currentEmployee.Employee_Role_ID == 1)
                    {
                        return RedirectToAction("Index", "SalesRep", currentEmployee.Employee_ID);
                    }
                    else if (currentEmployee.Employee_Role_ID == 2)
                    {
                        return RedirectToAction("Index", "BR", currentEmployee.Employee_ID);
                    }
                    else if (currentEmployee.Employee_Role_ID == 3)
                    {
                        return RedirectToAction("Index", "SingaporeEmployee", currentEmployee.Employee_ID);
                    }
                    else if (currentEmployee.Employee_Role_ID == 4)
                    {
                        return RedirectToAction("Index", "TechDirector", currentEmployee.Employee_ID);
                    }
                    else if (currentEmployee.Employee_Role_ID == 5)
                    {
                        return RedirectToAction("Index", "SeattleEmployee", currentEmployee.Employee_ID);
                    }
                    else if (currentEmployee.Employee_Role_ID == 7)
                    {
                        return RedirectToAction("Index", "Manager", currentEmployee.Employee_ID);
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
                    return RedirectToAction("Index", "Customer", currentCust);
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


        public ActionResult Profile()
        {
            if (currentEmployee != null)
            {
                //user is an employee
                return RedirectToAction("EmployeeProfile", "Home");//, currentEmployee);
            }


            else if (currentCust != null)
            {
                //user is a customer
                return RedirectToAction("CustProfile", "Home");//, currentCust);
            }
            return View();
        }


        [HttpGet]
        public ActionResult CreateCustomer()
        {
            ViewBag.Message = "Create Customer";
            return View();
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





        public ActionResult EmployeeProfile()
        {
            return View(currentEmployee);
        }
        public ActionResult CustProfile()
        {
            return View(currentCust);
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login", "Home");
        }
    }

}