using Microsoft.AspNetCore.Mvc;
using MVC_Model2.Models;
using MVC_Model2.Repository;
using System.Diagnostics;

namespace MVC_Model2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentRepository _studentRepository = null;

        public List<Student> getAllStudents()
        {
            return _studentRepository.getAllStudents();
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.getStudent(id);
		}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
			_studentRepository = new StudentRepository();
		}

        public IActionResult Index()
        {
            //var i = 1;
            //var st = new Student()
            //{
            //    Id = 1,
            //    Name = "홍길동",
            //    HP = "010-1111-1111",
            //    Major = "Computer Science"
            //};

            //ViewData["data1"] = st;


            //ViewData["data1"] = students;

            return View();
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