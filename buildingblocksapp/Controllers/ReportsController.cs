using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using buildingblocksapp;
using buildingblocksapp.Models;
using System.Composition;

namespace buildingblocksapp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly BuildingblocksContext _context;
        public ReportsController(BuildingblocksContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime start, DateTime end)
        {
            List<Report> AllElelements = new List<Report>();
            var orders = _context.Klantorders.Where(a => a.AanmaakDatum >= start && a.AanmaakDatum < end);
            foreach (var order in orders)
            {
                Report reportelement = new Report()
                {
                    Referentie = order.Referentienummer,
                    EndDate = end,
                    StartDate = start,
                    Aantal = order.Aantal,
                    OrderId = order.KlantorderId,
                    Type = order.Type
                };
                if (order.Type.ToString() == "A")
                {
                    reportelement.Blauw = 4;
                    reportelement.Rood = 2;
                    reportelement.Grijs = 1;
                }
                else if (order.Type.ToString() == "B")
                {
                    reportelement.Blauw = 4;
                    reportelement.Rood = 2;
                    reportelement.Grijs = 1;
                }
                else if (order.Type.ToString() == "C")
                {
                    reportelement.Blauw = 4;
                    reportelement.Rood = 2;
                    reportelement.Grijs = 1;
                }
                AllElelements.Add(reportelement);
            }

            return RedirectToAction("ReportScreen", "Reports", new {@reports = AllElelements});
        }
        public async Task<IActionResult> ReportScreen(List<Report> reports)
        {
            return View(reports);
        }
    }
}
