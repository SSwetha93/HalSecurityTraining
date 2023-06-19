using HalSecurityTrainingWeb.Data;
using HalSecurityTrainingWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HalSecurityTrainingWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentController(ApplicationDbContext dbContext) { 
                _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> studentList = _dbContext.Students;
            return View(studentList);
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student objStudent)
        {
            if (ModelState.IsValid)
            {
                objStudent.StudentId = new int();
                objStudent.RegistrationDate = DateTime.Now;
                _dbContext.Students.Add(objStudent);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objStudent);
        }
    }
}
