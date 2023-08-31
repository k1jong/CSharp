using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Report.Models;
using System.Diagnostics;

namespace Report.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReporterDBContext reporterDB;
        public HomeController(ReporterDBContext reporterDB)
        {
            this.reporterDB = reporterDB;
        }

        public async Task<IActionResult> Index()
        {
            var reportData = await reporterDB.Reporter.ToListAsync();
            return View(reportData);
        }
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if(id== null|| reporterDB == null)
            {
                return NotFound();
            }

            Reporter reportdata = reporterDB.Reporter.FirstOrDefault(x=>x.Id==id);

            return View(reportdata);
        }
        public IActionResult Delete(int? id)
        {
            var reportData = reporterDB.Reporter.FirstOrDefault(x => x.Id == id);
            return View(reportData);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id,Reporter reporter)
        {
            reporterDB.Reporter.Remove(reporter);
            await reporterDB.SaveChangesAsync();
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Reporter reporter)
        {
            await reporterDB.Reporter.AddAsync(reporter);
            await reporterDB.SaveChangesAsync();
            return RedirectToAction("index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Chart()
        {
            var reportData = reporterDB.Reporter.ToList();
            return View(reportData);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}