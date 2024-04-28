using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Register_Form_Project.Models;
using Register_Form_Project.Services;
using Register_Form_Project.Validators.FluentValidators;
using static Register_Form_Project.Models.JsonHandler;

namespace Register_Form_Project.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(user);

            if (result.IsValid)
            {
                UserDB.Users.Add(user);
                WriteData(UserDB.Users, "users");
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(user);
            }
        }
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var login = UserDB.Users.FirstOrDefault(u => u.Username == username && u.Password==password);
                return View("Login",login);
            }
            return RedirectToAction("GetAllUsers");
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            UserDB.Users.ToList();
            return View();
        }
        
    }
}
