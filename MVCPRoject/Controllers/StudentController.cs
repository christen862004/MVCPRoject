using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;

namespace MVCPRoject.Controllers
{
    public class StudentController : Controller
    {
        //Student/All
        public IActionResult All()
        {
            Employee emp;
            
            //Ask model data
            StudentBL studentBL = new StudentBL();
            List<Student> studentListModel = studentBL.GetAll();
            //send View 
            return View("ShowAll",studentListModel);//Model = List<student>
        }
        //Student/Details/1
        //Student/Details?id=2
        public IActionResult Details(int id)
        {
            StudentBL studentBL=new StudentBL();
            Student stdModel= studentBL.GetByID(id);
            if (stdModel != null)
            {
                return View("Details", stdModel);//view =DEtails , Model=Student
            }
            else
            {
                return NotFound();
            }
        }
    }
}
