using Microsoft.AspNetCore.Mvc;
using MVC_Typed.Models;
using System.Diagnostics;

namespace MVC_Typed.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			//EmployModel obj = new EmployModel
			//{
			//	EmpID = 100,
			//	EmpName = "홍길동",
			//	Designation = "대리",
			//	Salary = 25000
			//};

			////1. TempData["data1"] = obj;
			////2. ViewBag.Employee = obj;
			////3. ViewData["data1"] = obj;
			////4. Stronly Type

			//return View(obj);

			var myEmployees = new List<EmployModel>
			{
				new EmployModel {EmpID = 100,
				EmpName = "홍길동",
				Designation = "대리",
				Salary = 25000},
                new EmployModel {EmpID = 200,
                EmpName = "이순신",
                Designation = "부장",
                Salary = 50000},
                new EmployModel {EmpID = 300,
                EmpName = "강감찬",
                Designation = "상무",
                Salary = 75000},
            };

			return View(myEmployees);
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