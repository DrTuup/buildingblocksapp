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
        private buildingblocksdbContext db = new buildingblocksdbContext();
        // GET: AccountManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report(DateTime start, DateTime end)
        {
            int ordercount = db.Klantorders.Where(a => a.aanmaakdatum >= start && a.voldaandatum <= end).Count();
            return View();
        }
    }
}