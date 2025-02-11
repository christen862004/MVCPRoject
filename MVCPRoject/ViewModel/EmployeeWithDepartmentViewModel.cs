using MVCPRoject.Models;

namespace MVCPRoject.ViewModel
{
    public class EmployeeWithDepartmentViewModel
    {
        //public int DeptID { get; set; }
        //public string DeptName { get; set; }
        public int  EmpID { get; set; }
        public string  EmpName { get; set; }
        public string EmpImage { get; set; }
        public List<DEpartmentViewModel> Department { get; set; }
    }
    public class DEpartmentViewModel
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
