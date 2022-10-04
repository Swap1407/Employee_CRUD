using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data.SqlClient;

namespace Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        //meaningful name, make it readonly
        private readonly IEmployeeDataAccessLayer _dataLayerFunction;

        public EmployeeController(IEmployeeDataAccessLayer dataLayerFunction)
        {
            _dataLayerFunction = dataLayerFunction;
        }

        public ActionResult GetAllEmployees()
        {
            //first assign functions return value to some variable then pass it to view. because you might need to perform some mapping or UI specific other processing 
            //as required 
            var employeelist = _dataLayerFunction.GetEmployeeList();
            return View(employeelist);
        }

        public ActionResult EmployeeDetails(int Id)
        {
            var employee = _dataLayerFunction.GetEmployee(Id);
            return View(employee);
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
            
                if (ModelState.IsValid)
                {
                    var employeee = _dataLayerFunction.AddEmployee(employee);
                    return View("EmployeeDetails",employeee);
                }
                return View();
            
        }

        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            var employee = _dataLayerFunction.GetEmployee(Id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            
                if (ModelState.IsValid)
                {
                    var employeee = _dataLayerFunction.SaveEmployee(employee);
                    return View("EmployeeDetails", employeee);
                }
                return View();
            
        }

        public ActionResult DeleteEmployee(int Id)
        {
            var employeee = _dataLayerFunction.DeleteEmployee(Id);
            return View("EmployeeDetails", employeee);
        }
    }
}
