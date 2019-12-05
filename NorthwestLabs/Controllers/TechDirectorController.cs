using NorthwestLabs.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class TechDirectorController : Controller
    {
        private LabContext db = new LabContext();

        // GET: TechDirector
        public ActionResult Index()
        {
            return View(db.WorkOrders);
        }
    }
}