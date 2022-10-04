using System.ComponentModel.DataAnnotations;

namespace Employee_CRUD.Models
{
    public class Employee
    {
        // make attributes required which are necessary
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please Provide Valid Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Department")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please Provide Valid Department Name")]
        public string Department { get; set; }

    }
}
