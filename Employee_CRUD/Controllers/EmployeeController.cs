using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data.SqlClient;

namespace Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeDataAccessLayer _function;
        
        public EmployeeController(IEmployeeDataAccessLayer function)
        {
            _function = function;
        }

        public ActionResult GetAllEmployees()
        {
            return View(_function.GetEmployeeList());
        }

        public ActionResult EmployeeDetails(int Id)
        {
            return View(_function.GetEmployee(Id));
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            _function.AddEmployee(employee);
            return RedirectToAction("GetAllEmployees");
        }

        
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            return View(_function.GetEmployee(Id));
        }

        
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            _function.SaveEmployee(employee);
            return RedirectToAction("GetAllEmployees");
        }

        public ActionResult DeleteEmployee(int Id)
        {
            _function.DeleteEmployee(Id);
            return RedirectToAction("GetAllEmployees");
        }
    }
}
