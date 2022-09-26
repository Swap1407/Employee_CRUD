using System.Data.SqlClient;

namespace Employee_CRUD.Models
{
    public class EmployeeFunctionLayer : IEmployeeFunctionLayer
    {
        public void AddEmployee(Employee employee)
        {
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDepartment = new SqlParameter();
                paramDepartment.ParameterName = "@Department";
                paramDepartment.Value = employee.Department;
                cmd.Parameters.Add(paramDepartment);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveEmployee(Employee employee)
        {
            string ConnectionString = "data source=.; database=Employee_Data; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SaveEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDepartment = new SqlParameter();
                paramDepartment.ParameterName = "@Department";
                paramDepartment.Value = employee.Department;
                cmd.Parameters.Add(paramDepartment);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
