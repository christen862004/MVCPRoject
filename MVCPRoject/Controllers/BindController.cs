using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;

namespace MVCPRoject.Controllers
{
    public class BindController : Controller
    {
        //accepted parameter data type ==>Model Binding Get value from request
        //Primitive type int string ..
        //Bind/TestPrimitive?age=12&name=Ahmed&id=1
        //Bind/TestPrimitive/1?age=12&name=Ahmed
        //http://localhost:42622/Bind/TestPrimitive/10?name=Ahmed&age=100&color[1]=red&color[0]=blue
        public IActionResult TestPrimitive(int age,string name,int id,string[] color)
        {
            return Content($"{age} \t {name}");
        }

        //Collection (list ,Dictionar)
        //Bind/TestDic?name=Christen&phoneBook[ahmed]=123&phoneBook[mohamed]=567
        public IActionResult TestDic(Dictionary<string,string> phoneBook,string name)
        {
            return Content("ok");
        }

        //Complex Type Class
        ////public IActionResult TestObj
        ////    (int Id,string Name ,string ManagerName, List<Employee>? Employees)
        //Bind/TestObj?id=1&name=DotNet&ManagerName=Ahmed&Employees[0].Name=Ali
        //dept[0].id=1&dept[1].id=12
       // public IActionResult TestObj(List<Department> dept)
        public IActionResult TestObj(Department dept)
        {
            return Content("ok");
        }
    }
}
