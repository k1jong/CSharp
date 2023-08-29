using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDb;
        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }
        public IActionResult Index()
        {

            var stdData = studentDb.Student.ToList();
            return View(stdData);
        }
        //Get화면
        public IActionResult Create()
        {
            return View();
        }
        // POST: 삽입기능
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Hp")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentDb.Add(student);
                await studentDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}