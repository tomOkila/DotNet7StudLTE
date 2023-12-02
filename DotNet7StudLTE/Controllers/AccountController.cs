using DotNet7StudLTE.BusLogic;
using DotNet7StudLTE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7StudLTE.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger _logger;

        public AccountController(
           ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public  IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email, Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                //check that the user supplies both the email and password.
                if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
                {
                    TempData["TransError"]  = "Invalid details passed, Please try again later";
                    _logger.LogError("Invalid details passed, Please try again later");
                    return View(login);
                }
            
            
                var resultLogin = Authenticate.GetUserData(login.Password, login.Email);
                
                if (resultLogin.Rows.Count>0)
                {
                    _logger.LogInformation("User logged in.");

                    //add authentication session
                    HttpContext.Session.SetString("UserID", resultLogin.Rows[0]["UserID"].ToString());
                    HttpContext.Session.SetString("FullName", resultLogin.Rows[0]["FullName"].ToString());
                    HttpContext.Session.SetString("Email", resultLogin.Rows[0]["Email"].ToString());
                    HttpContext.Session.SetString("Theme", resultLogin.Rows[0]["Theme"].ToString());
                    //log user session
                    LogData.LogSessionData(resultLogin.Rows[0]["UserId"].ToString(), "", "", "User Login");

                    return RedirectToAction("Index","Dashboard");
                }

            }
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }


    }
}
