using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data.SqlClient;

namespace Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        //meaningful name, make it readonly
        private IEmployeeDataAccessLayer _function;
        
        public EmployeeController(IEmployeeDataAccessLayer function)
        {
            _function = function;
        }

        public ActionResult GetAllEmployees()
        {
            //first assign functions return value to some variable then pass it to view. because you might need to perform some mapping or UI specific other processing 
            //as required 
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
            //check if model is valid in create and edit
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
