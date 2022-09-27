namespace Employee_CRUD.Models
{
    public interface IEmployeeDataAccessLayer
    {
        public void AddEmployee(Employee employee);
        public void SaveEmployee(Employee employee);
        public List<Employee> GetEmployeeList();
        public Employee GetEmployee(int Id);
        public void DeleteEmployee(int Id);
    }
}
