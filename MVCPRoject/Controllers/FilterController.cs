using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Filters;
using System.Security.Claims;

namespace MVCPRoject.Controllers
{
    [HandelError]
    public class FilterController : Controller
    {
        //Filter/index
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            //get info from logged user
            Claim IdClaim= User.Claims.FirstOrDefault(c => c.Type == "UserID");
            int id =int.Parse(IdClaim.Value);
            string name = User.Identity.Name;

            return Content($"Hello id={id}\t name={name}");           
        }

        public IActionResult Index2()
        {
            throw new Exception("Action 2 throw exception");
            return View();
        }
    }
}
