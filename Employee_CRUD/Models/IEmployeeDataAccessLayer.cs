namespace Employee_CRUD.Models
{
    public interface IEmployeeDataAccessLayer
    {
        public Employee AddEmployee(Employee employee);
        public Employee SaveEmployee(Employee employee);
        public List<Employee> GetEmployeeList();
        public Employee GetEmployee(int Id);
        public Employee DeleteEmployee(int Id);
    }
}
