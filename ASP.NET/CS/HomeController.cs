using Microsoft.AspNetCore.Mvc;

namespace WebEmpty_Quiz2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/index")]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        public IActionResult Index(DateTime start,DateTime last) 
        {
            ViewBag.result = (last-start).ToString("dd");
            return View();
        }

        public IActionResult BMI()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BMI(double he,int kg,string se)
        {
            he *=0.01;
            if (se == "남성")
            {
                he = he * he * 22;
            }
            else
            {
                he = he * he * 21;
            }

            if (kg / he * 100 < 90)
            {
                ViewBag.result1 = "저체중";
            }
            else if (90 <= kg / he * 100 && kg / he * 100 <= 110)
            {
                ViewBag.result1 = "정상 체중";
            }
            else if (110 <= kg / he * 100 && kg / he * 100 < 120)
            {
                ViewBag.result1 = "과체중";
            }
            else if (120 <= kg / he * 100 && kg / he * 100 < 130)
            {
                ViewBag.result1 = "경도 비만";
            }
            else if (130 <= kg / he * 100 && kg / he * 100 < 160)
            {
                ViewBag.result1 = "중정도 비만";
            }
            else
            {
                ViewBag.result1 = "고도 비만";
            }

            return View();
        }

    }
}
