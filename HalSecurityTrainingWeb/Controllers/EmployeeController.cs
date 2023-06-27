using HalSecurityTrainingWeb.Data;
using HalSecurityTrainingWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HalSecurityTrainingWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeController(ApplicationDbContext dbContext) { 
                _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employeeList = _dbContext.Employees.ToList();
            return View(employeeList);
        }

        //GET
        public IActionResult Create()
        {
           return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee objEmployee)
        {
            if (ModelState.IsValid)
            {
                objEmployee.RegistrationDate = DateTime.Now;
                _dbContext.Employees.Add(objEmployee);
                _dbContext.SaveChanges();
				TempData["success"] = "Employee Added Successfully";
				return RedirectToAction("Index");
            }
            return View(objEmployee);
        }

		//GET
		public IActionResult Edit(int? employeeId)
		{
			if (employeeId == null || employeeId == 0){
				return NotFound();
			}

			var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employee == null){
                return NotFound();
            }
			return View(employee);
		}

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee objEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == objEmployee.EmployeeId);
                employee.FirstName = objEmployee.FirstName;
                employee.LastName = objEmployee.LastName;
                employee.DOB = objEmployee.DOB;

                _dbContext.Employees.Update(employee).Property(x => x.Id).IsModified = false;
                _dbContext.SaveChanges();
                TempData["success"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(objEmployee);
        }

		//GET
		public IActionResult Delete(int? employeeId)
		{
			if (employeeId == null || employeeId == 0)
			{
				return NotFound();
			}

			var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
			if (employee == null)
			{
				return NotFound();
			}
			return View(employee);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? employeeId)
		{
			var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employee == null)
                return NotFound();
			

			_dbContext.Employees.Remove(employee);
			_dbContext.SaveChanges();
			TempData["success"] = "Employee Deleted Successfully";
			return RedirectToAction("Index");
		}
	}
}
