using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCPRoject.Models;
using MVCPRoject.ViewModel;

namespace MVCPRoject.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyContext context = new CompanyContext();

        public IActionResult CheckSalary(int Salary ,string Address) {
            if (Address == "Alex")
            {
                if (Salary % 3 == 0)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        #region New
        public IActionResult New()
        {
            
           // IEnumerable<SelectListItem> dept = context.Departments.ToList();
            //ViewData["DeptList"] =new SelectList( context.Departments.ToList(),"Id","Name");
            ViewData["DeptList"] = context.Departments.ToList();
            return View("New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee EmpFromRequest)
        {
            if(ModelState.IsValid==true)
            {
                try
                {
                    context.Employees.Add(EmpFromRequest);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    //1) custom error limitied in this action
                    // ModelState.AddModelError("DepartmentID", "Please Select DEpartment");//Span DepartmentID
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);//more General display Div
                }
            }
            //////////////////////////////////
            ViewData["DeptList"] = context.Departments.ToList();
            return View("New", EmpFromRequest);
        }

        #endregion


        #region Edit
        public IActionResult Edit(int id)
        {

            Employee empModel=context.Employees.FirstOrDefault(e=>e.Id==id);
            
            if (empModel != null)
            {
                //declare
                EmployeeWithDeptListViewModel EmpViewModel=
                    new EmployeeWithDeptListViewModel();
                //mapping
                EmpViewModel.Id = empModel.Id;
                EmpViewModel.Name = empModel.Name;
                EmpViewModel.Salary = empModel.Salary;
                EmpViewModel.ImageURL = empModel.ImageURL;
                EmpViewModel.Address = empModel.Address;
                EmpViewModel.Jobtitle = empModel.Jobtitle;
                EmpViewModel.DepartmentID = empModel.DepartmentID;

                EmpViewModel.DeptList=context.Departments.ToList();
                //return viewmode
                return View("Edit", EmpViewModel);//view=Edit ,Model =EmployeeWithDeptListViewModel
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFromReuest)
        {
            if(EmpFromReuest.Name != null) {
                //old reference from datav=base
                Employee EmpFromDatabase=
                    context.Employees.FirstOrDefault(e => e.Id == EmpFromReuest.Id);
                //update using new empfromreqquest
                EmpFromDatabase.Name=EmpFromReuest.Name;
                EmpFromDatabase.Address=EmpFromReuest.Address;
                EmpFromDatabase.Jobtitle=EmpFromReuest.Jobtitle;
                EmpFromDatabase.ImageURL=EmpFromReuest.ImageURL;
                EmpFromDatabase.Salary=EmpFromReuest.Salary;
                EmpFromDatabase.DepartmentID=EmpFromReuest.DepartmentID;

                //save change
                context.SaveChanges();
                return RedirectToAction("Index");

            }
           
            //VM contain Employee Data Only need to full deptList
            EmpFromReuest.DeptList = context.Departments.ToList();
            return View("Edit", EmpFromReuest);
        }


        #endregion
     
        #region Actions Details

        public IActionResult testMixData(int id)
        {
            //logic
            string msg = "Hello FRom BackEnd";
            int temp = 10;
            string color = "blue";
            List<string> brch = new List<string>();
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

            return View("testMixDataUsingVM", EmpVM);//View="" ,Model =EmployeeWitColorMsgBrachNamesViewModel
        }


        #endregion

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
