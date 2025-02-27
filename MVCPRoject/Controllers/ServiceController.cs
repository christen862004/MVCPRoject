using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;
using MVCPRoject.Repository;
using System.Security.Claims;

namespace MVCPRoject.Controllers
{
    public class ServiceController : Controller
    {
     
        private readonly IRepository<Department> deptRepo;

        public ServiceController(IRepository<Department> deptRepo)//ask container
        {
            this.deptRepo = deptRepo;
        }

        public IActionResult Index()
        {
            ViewBag.ID = deptRepo.ID;
            return View("Index");
        }
    }
}
