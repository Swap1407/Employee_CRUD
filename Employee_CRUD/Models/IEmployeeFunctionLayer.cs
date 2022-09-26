namespace Employee_CRUD.Models
{
    public interface IEmployeeFunctionLayer
    {
        public void AddEmployee(Employee employee);
        public void SaveEmployee(Employee employee);
    }
}
