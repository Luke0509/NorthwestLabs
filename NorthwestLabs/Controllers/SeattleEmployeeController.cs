using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    [Authorize]
    public class SeattleEmployeeController : Controller
    {
        // GET: SeattleEmployee
        public ActionResult Index()
        {
            return View();
        }
    }
}