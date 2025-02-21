using MVCPRoject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPRoject.ViewModel
{
    public class EmployeeWithDeptListViewModel
    {
        //Employee Class
        public int Id { get; set; }//PK

        [Display(Name ="Employee NAme")]//label
        [DataType(DataType.EmailAddress)]//Editor
        public string Name { get; set; }
       
        public int Salary { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? Jobtitle { get; set; }

        [Display(Name ="Departemtn Name")]
        public int DepartmentID { get; set; }
        
        public List<Department>? DeptList { get; set; }
    }
}
