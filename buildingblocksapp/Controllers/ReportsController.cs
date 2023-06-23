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
            var orders = _context.Klantorders.Where(a => a.AanmaakDatum >= start && a.AanmaakDatum < end).ToList();
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
                    reportelement.Blauw = 3 * order.Aantal;
                    reportelement.Rood = 4 * order.Aantal;
                    reportelement.Grijs = 2 * order.Aantal;
                }
                else if (order.Type.ToString() == "B")
                {
                    reportelement.Blauw = 2 * order.Aantal;
                    reportelement.Rood = 2 * order.Aantal;
                    reportelement.Grijs = 4 * order.Aantal;
                }
                else if (order.Type.ToString() == "C")
                {
                    reportelement.Blauw = 3 * order.Aantal;
                    reportelement.Rood = 3 * order.Aantal;
                    reportelement.Grijs = 2 * order.Aantal;
                }
                AllElelements.Add(reportelement);
            }

            return View("ReportScreen", AllElelements);
        }
        public async Task<IActionResult> ReportScreen(List<Report> reports)
        {
            return View(reports);
        }
    }
}
