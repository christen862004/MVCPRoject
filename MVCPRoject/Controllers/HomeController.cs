using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;
using System.Diagnostics;

namespace MVCPRoject.Controllers
{
    public class HomeController : Controller
    {
        ///Method call Actions <summary>
        /// Action must be public
        /// Action cant be static
        /// Action Cant be overload (only in one case)

        //Home/ShowMsg
        public ContentResult ShowMsg()
        {
            //logic
            //create obj
            ContentResult result = new ContentResult();
            //fill
            result.Content = "First Content from Action";
            //return 
            return result;
        }
        //home/showView
        public ViewResult ShowView()
        {
            //logic
            //create obj
            ViewResult result = new ViewResult();
            //fill
            result.ViewName = "View1";
            //restutn
            return result;
        }

        //Home/ShowMix?id=10&name=ahmed [query string]
        //Home/ShowMix/10?name=ahmed [query string]

        public IActionResult ShowMix(int id,string name)
        {
            if (id % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                //logic
                return Content("hiiiiiiiii");
            }
        }

        //[NonAction]//not url "Endpoint"/Home/view
        //public  ViewResult View(string viewName)
        //{
        //    ViewResult result = new ViewResult();
        //    //fill
        //    result.ViewName = viewName;
        //    //restutn
        //    return result;
        //}
        /// <summary>
        /// Action can return 
        /// Content     ==> ContentResult
        /// View        ==> ViewResult
        /// Json        ==> JsonResult
        /// NotFound    ==> NotFoundResult
        /// Empty       ==> EmptyREs
        /// unAuthorize
        /// ....
        /// </summary>




      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Home/Index
        public IActionResult Index()
        {
            return View();
        }
        //Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
