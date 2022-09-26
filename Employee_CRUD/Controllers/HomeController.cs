using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Employee_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Employee emp)
        {
            Employee employee = new Employee();
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                String query = "Select * from Employees where Id = " + emp.Id.ToString();
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

    }
}