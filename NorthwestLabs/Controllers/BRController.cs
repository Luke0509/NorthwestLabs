using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class BRController : Controller
    {
        private LabContext db = new LabContext();

        public ActionResult Index()
        {
            return View();
        }

    }
}
