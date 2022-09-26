using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data.SqlClient;

namespace Employee_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeFunctionLayer _function;
        
        public EmployeeController(IEmployeeFunctionLayer funct)
        {
            _function = funct;
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

        public ActionResult GetAllEmployees()
        {
            List<Employee> emp_List = new List<Employee>();
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employees", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
 
                while (sdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = (int)sdr["Id"];
                    emp.Name = (string)sdr["Name"];
                    emp.Department = (string)sdr["Department"];
                    emp_List.Add(emp);
                }
            }
            return View(emp_List);
        }
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            Employee employee = new Employee();
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                String query = "Select * from Employees Where Id = " + Id.ToString();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                employee.Id = (int)sdr["Id"];
                employee.Name = (string)sdr["Name"];
                employee.Department = (string)sdr["Department"];

            }
            return View(employee);
        }

        
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            _function.SaveEmployee(employee);
            return RedirectToAction("GetAllEmployees");
        }

        public ActionResult DeleteEmployee(Employee emp)
        {
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                String query = "Delete from Employees where Id = " + emp.Id.ToString();
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
            }
            return RedirectToAction("GetAllEmployees");
        }
    }
}
