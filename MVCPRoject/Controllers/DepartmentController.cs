using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;

namespace MVCPRoject.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext context = new CompanyContext();
        public IActionResult Index()//action
        {
            List<Department> DeptsModel = context.Departments.ToList();
            return View("Index",DeptsModel);//View= Index,Model List<department>
        }
        //Link 
        public IActionResult New()
        {
            return View("New");//Model null Exception
        }

        //submit button[dry]
        ///department/SaveNew?Name=Dept1&ManagerName=Ahmed <summary>
        /// department/SaveNew?Name=Dept1
        //any action can handel request get or post
        [HttpPost]
        public IActionResult SaveNew(Department deptFromRequest)
        {
            if (deptFromRequest.Name != null)
            {
                context.Add(deptFromRequest);//memory
                context.SaveChanges();//database
                return RedirectToAction("Index");//call action
                                                    //return View("Index",context.Departments.ToList());
            }
            return View("New", deptFromRequest);//call view =new ,model =department
            #region Comment
            //if (Request.Method == "POST")
            //{
            //}
            //else
            //{
            //    return NotFound();
            //}
            #endregion

        }
    }
}
