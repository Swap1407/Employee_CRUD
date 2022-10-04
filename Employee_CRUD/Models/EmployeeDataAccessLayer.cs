using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Employee_CRUD.Models
{
    public class EmployeeDataAccessLayer : IEmployeeDataAccessLayer
    {
        //it should be readonly
        // Add, Save, Update always returns the affected row from table
        //Also do exception handling in case there is some exception in sp calling or processing

        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeDataAccessLayer> _logger;
        private readonly string ConnectionString ;
        public EmployeeDataAccessLayer(IConfiguration configuration, ILogger<EmployeeDataAccessLayer> logger)
        {
            _configuration = configuration;
            _logger = logger;
            ConnectionString = _configuration.GetConnectionString("EmployeeConnectionString");
        }
        public Employee AddEmployee(Employee employee)
        {
            var addedemployee = new Employee();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand("AddEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    
                    var EmployeeIdoutPutParameter = command.Parameters.Add("@EmployeeId", SqlDbType.Int);
                    EmployeeIdoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeNameoutPutParameter = command.Parameters.Add("@EmployeeName", SqlDbType.VarChar,60);
                    EmployeeNameoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeDepartmentoutPutParameter = command.Parameters.Add("@EmployeeDepartment", SqlDbType.VarChar, 30);
                    EmployeeDepartmentoutPutParameter.Direction = ParameterDirection.Output;
                    
                    connection.Open();
                    command.ExecuteNonQuery();

                    addedemployee.Id = (int)EmployeeIdoutPutParameter.Value;
                    addedemployee.Name = (string)EmployeeNameoutPutParameter.Value;
                    addedemployee.Department = (string)EmployeeDepartmentoutPutParameter.Value;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return addedemployee;
        }

        public List<Employee> GetEmployeeList()
        {
            var employeeList = new List<Employee>();
            try
            {  
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand("GetAllEmployees", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    var sqldatareader = command.ExecuteReader();

                    while (sqldatareader.Read())
                    {
                        // use object initializer here
                        var employee = new Employee()
                        {
                            Id = (int)sqldatareader["Id"],
                            Name = (string)sqldatareader["Name"],
                            Department = (string)sqldatareader["Department"]
                        };
                        employeeList.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            var employee = new Employee();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand("GetEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);

                    connection.Open();
                    var sqldatareader = command.ExecuteReader();
                    sqldatareader.Read();

                    // use object initializer here
                    employee.Id = (int)sqldatareader["Id"];
                    employee.Name = (string)sqldatareader["Name"];
                    employee.Department = (string)sqldatareader["Department"];
                    /*var employee = new Employee()
                    {
                        Id = (int)sqldatareader["Id"],
                        Name = (string)sqldatareader["Name"],
                        Department = (string)sqldatareader["Department"]
                    };*/
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return employee;
        }

        public Employee SaveEmployee(Employee employee)
        {
            var savedemployee = new Employee();
            try
            {
                _logger.LogInformation("employee edit started");
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand("EditEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Department", employee.Department);

                    var EmployeeIdoutPutParameter = command.Parameters.Add("@EmployeeId", SqlDbType.Int);
                    EmployeeIdoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeNameoutPutParameter = command.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 60);
                    EmployeeNameoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeDepartmentoutPutParameter = command.Parameters.Add("@EmployeeDepartment", SqlDbType.VarChar, 30);
                    EmployeeDepartmentoutPutParameter.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    savedemployee.Id = (int)EmployeeIdoutPutParameter.Value;
                    savedemployee.Name = (string)EmployeeNameoutPutParameter.Value;
                    savedemployee.Department = (string)EmployeeDepartmentoutPutParameter.Value;
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return savedemployee;
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee deletedemploye= new Employee() ;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand("DeleteEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);

                    var EmployeeIdoutPutParameter = command.Parameters.Add("@EmployeeId", SqlDbType.Int);
                    EmployeeIdoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeNameoutPutParameter = command.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 60);
                    EmployeeNameoutPutParameter.Direction = ParameterDirection.Output;

                    var EmployeeDepartmentoutPutParameter = command.Parameters.Add("@EmployeeDepartment", SqlDbType.VarChar, 30);
                    EmployeeDepartmentoutPutParameter.Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    deletedemploye.Id = (int)EmployeeIdoutPutParameter.Value;
                    deletedemploye.Name = (string)EmployeeNameoutPutParameter.Value;
                    deletedemploye.Department = (string)EmployeeDepartmentoutPutParameter.Value;
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return deletedemploye;
        }
    }
}
