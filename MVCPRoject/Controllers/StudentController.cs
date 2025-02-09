using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;

namespace MVCPRoject.Controllers
{
    public class StudentController : Controller
    {
        //Student/All
        public IActionResult All()
        {
            //Ask model data
            StudentBL studentBL = new StudentBL();
            List<Student> studentListModel = studentBL.GetAll();
            //send View 
            return View("ShowAll",studentListModel);
        }
    }
}
