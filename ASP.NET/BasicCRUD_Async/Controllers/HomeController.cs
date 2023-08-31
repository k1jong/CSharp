using BasicCRUD2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasicCRUD2.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDb;
        public HomeController(StudentDBContext studentDb)
        {
            this.studentDb = studentDb;
        }
        //public IActionResult Index()
        //{
        //    var students = studentDb.Student.ToList();
        //    return View(students);
        //}
        public async Task<IActionResult> Index()
        {
            var students = await studentDb.Student.ToListAsync<Student>();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(Student std)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        studentDb.Student.Add(std);
        //        studentDb.SaveChanges();
        //        return RedirectToAction("Index","Home");
        //    }
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDb.Student.AddAsync(std);
                await studentDb.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Details(int? id) // ? 값이 없어도 뜨게 해줌
        {
            if(id==null || studentDb.Student==null)
            {
                return NotFound();
            }

            Student stdData = studentDb.Student.FirstOrDefault(i => i.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || studentDb.Student == null)
            {
                return NotFound();
            }

            var stdData = studentDb.Student.Find(id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student std)
        {
            if (ModelState.IsValid)
            {
                studentDb.Update(std);
                await studentDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(std);
        }
        public IActionResult Delete(int? id)
        {
            var stdData= studentDb.Student.FirstOrDefault(x=>x.Id == id);
            return View(stdData);
        }
        [HttpPost,ActionName("Delete")]
        //public IActionResult Deleteconfirmed(int? id,Student std)
        //{
        //    if (id == null || studentDb.Student == null || std==null)
        //    {
        //        return NotFound();
        //    }
        //    studentDb.Student.Remove(std);
        //    studentDb.SaveChanges();


        //    return RedirectToAction("index");
        //}
        public async Task<IActionResult> Deleteconfirmed(int? id)
        {
            var std = studentDb.Student.FirstOrDefault(y=>y.Id == id);

            studentDb.Student.Remove(std);
            await studentDb.SaveChangesAsync();


            return RedirectToAction("index");
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