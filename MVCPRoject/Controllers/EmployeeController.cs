using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;
using MVCPRoject.ViewModel;

namespace MVCPRoject.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();
        public EmployeeController()
        {
            
        }

        public IActionResult testMixData(int id)
        {
            //logic
            string msg = "Hello FRom BackEnd";
            int temp = 10;
            string color = "blue";
            List<string> brch=new List<string>();
            brch.Add("Assiut");
            brch.Add("Cairo");
            brch.Add("Alex");
            brch.Add("Mansuora");
            //Send Data To Front (View)
            ViewData["Msg"] = msg;//boxing to object
            ViewData["Temp"] = temp;//boxing to object
            ViewData["Clr"] = "red";//boxing to object
            ViewData["Brch"] = brch;//boxing to object
            //ViewBag.xyz = "Alaa";
            //ViewBag.Clr = "Blue";//ViewData["Clr"]="Blue";
            // override blues


            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            return View("testMixData", empModel);// View=testMixData   ,Model =Employee
        }
        
        public IActionResult testMixDataUsingVM(int id)
        {
            //Collect data
            string msg = "Hello FRom BackEnd";
            int temp = 10;
            string color = "blue";
            List<string> brch = new List<string>();
            brch.Add("Assiut");
            brch.Add("Cairo");
            brch.Add("Alex");
            brch.Add("Mansuora");
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            //mapping takke collect ==>VM
            EmployeeWitColorMsgBrachNamesViewModel EmpVM =
                new EmployeeWitColorMsgBrachNamesViewModel();
            EmpVM.EmpID = EmpModel.Id;
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.Message = msg;
            EmpVM.Color = color;
            EmpVM.Temp = temp;
            EmpVM.Branches = brch;

            return View("testMixDataUsingVM",EmpVM);//View="" ,Model =EmployeeWitColorMsgBrachNamesViewModel
        }


        #region 
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
        #endregion
    }
}
