using Microsoft.AspNetCore.Mvc;

namespace MVCPRoject.Controllers
{
    public class RouteController : Controller
    {
        //Route/Method1
        [Route("m1/{name:alpha}/{age?}")]//remove Route/Method1
        public IActionResult Method1(string name,int age)
        {
            return Content("M1");
        }
        //m2
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
