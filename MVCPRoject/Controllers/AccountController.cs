using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCPRoject.Models;
using MVCPRoject.Repository;
using MVCPRoject.ViewModel;
using System.Security.Claims;

namespace MVCPRoject.Controllers
{
    
    public class AccountController : Controller
    {
        IAccountRepository accountRepo;
        public AccountController(IAccountRepository accountRepo)
        {
            this.accountRepo = accountRepo;
        }
        //Register
        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userFromRequest)
        {
            if (ModelState.IsValid)
            {
                //check validd account
                UserAccount userFRomDB=
                    accountRepo.FindAccount(userFromRequest.UserName, userFromRequest.Password);
                if(userFRomDB != null) {
                    //create cookie
                    ClaimsIdentity claims = new ClaimsIdentity(
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    //id 
                    claims.AddClaim(new Claim("UserID", userFRomDB.Id.ToString()));
                    claims.AddClaim(new Claim(ClaimTypes.Name, userFRomDB.UserName));
                    claims.AddClaim(new Claim(ClaimTypes.Role,"Admin"));

                    ClaimsPrincipal principle =
                        new ClaimsPrincipal(claims);
                    await HttpContext.SignInAsync(principle);
                    //index Employee
                    return RedirectToAction("Index", "Filter");
                }
                else
                {
                    ModelState.AddModelError("", "User name or PAssword Invalid");
                }
            }
            return View("Login",userFromRequest);
        }
        //reset passsword
        //logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
    }
}
