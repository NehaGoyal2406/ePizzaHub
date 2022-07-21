using DAL.Entities;
using ePizzaHub.Models;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService=    authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            UserModel user = _authService.ValidateUser(model.Email, model.Password);
            if(user!=null)
            { 
                if(user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "DashBoard", new { area = "Admin" });
                }
                else if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "DashBoard", new { area = "User" });
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now
                };
                bool result= _authService.CreateUser(user, "User");
                if (result)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
            
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Login");
        }
    }
}
