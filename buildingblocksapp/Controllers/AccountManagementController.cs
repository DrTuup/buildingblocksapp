using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using buildingblocksapp.Models;
using System.Web.Routing;
using System.Web.Optimization;

namespace buildingblocksapp.Controllers
{
    public class AccountManagementController : Controller
    {
        // GET: AccountManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}