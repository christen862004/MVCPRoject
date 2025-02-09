using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;

namespace MVCPRoject.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()
        {
            List<Employee> EmpListModel=
                context.Employees.ToList();

            return View("Index",EmpListModel);//view =Index ,Model =List<Employee>
        }

        public IActionResult DEtails(int id)
        {
            //SingleOrDefault | FirstOrDefault
            Employee EmpModel = context.Employees.FirstOrDefault(d=>d.Id==id);
            return View("DEtails",EmpModel);//View=DEtails ,Model Type "Employee"
        }
    }
}
