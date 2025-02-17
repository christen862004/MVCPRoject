using MVCPRoject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPRoject.ViewModel
{
    public class EmployeeWithDeptListViewModel
    {
        //Employee Class
        public int Id { get; set; }//PK
        public string Name { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? Jobtitle { get; set; }
        public int DepartmentID { get; set; }
        //ListDepartment
        public List<Department> DeptList { get; set; }
    }
}
