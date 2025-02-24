using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;
using MVCPRoject.Repository;

namespace MVCPRoject.Controllers
{
    //DIP (dont mae high Level Cals  Based On Low LEvel Class =>Interf
    public class DepartmentController : Controller
    {
        //DIP
        IRepository<Department> departmentRepository;
        //DI as not create
        public DepartmentController(IRepository<Department> deptREpo)//container service provider
        {
            departmentRepository = deptREpo;
        }

        public IActionResult Index()//action
        {
            List<Department> DeptsModel = departmentRepository.GetAll();
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
                departmentRepository.Insert(deptFromRequest);//memory
                departmentRepository.Save();
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
