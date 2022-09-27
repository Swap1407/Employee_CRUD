using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Employee_CRUD.Models
{
    public class EmployeeDataAccessLayer : IEmployeeDataAccessLayer
    {
        private IConfiguration _configuration;

        public EmployeeDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void AddEmployee(Employee employee)
        {
            var ConnectionString = _configuration.GetConnectionString("connString");
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("AddEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Department", employee.Department);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetEmployeeList()
        {
            var employee_List = new List<Employee>();
            var ConnectionString = _configuration.GetConnectionString("connString");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                var sqldatareader = command.ExecuteReader();

                while (sqldatareader.Read())
                {
                    var employee = new Employee();
                    employee.Id = (int)sqldatareader["Id"];
                    employee.Name = (string)sqldatareader["Name"];
                    employee.Department = (string)sqldatareader["Department"];
                    employee_List.Add(employee);
                }
            }
            return employee_List;
        }

        public Employee GetEmployee(int Id)
        {
            var employee = new Employee();
            var ConnectionString = _configuration.GetConnectionString("connString");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("GetEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                var sqldatareader = command.ExecuteReader();
                sqldatareader.Read();
                employee.Id = (int)sqldatareader["Id"];
                employee.Name = (string)sqldatareader["Name"];
                employee.Department = (string)sqldatareader["Department"];

            }
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            var ConnectionString = _configuration.GetConnectionString("connString");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("EditEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Department", employee.Department);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int Id)
        {
            var ConnectionString = _configuration.GetConnectionString("connString");

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
