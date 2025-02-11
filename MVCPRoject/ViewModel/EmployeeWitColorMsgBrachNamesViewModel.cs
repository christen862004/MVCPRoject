using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MVCPRoject.ViewModel
{
    public class EmployeeWitColorMsgBrachNamesViewModel
    {
        //hidden property Salary - imag -jobtit
        //Change NAme Property
        public int EmpID { get; set; }
        public string EmpName { get; set; }

        //Extra info
        public int Temp { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
    }
}
