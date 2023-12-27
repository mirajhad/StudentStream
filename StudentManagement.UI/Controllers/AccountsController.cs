using Microsoft.AspNetCore.Mvc;
using StudentManagement.BLL.Services;
using StudentManagement.Models;
using System.Text.Json;

namespace StudentManagement.UI.Controllers
{
    public class AccountsController : Controller
    {
        private IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            LoginViewModel vm = _accountService.Login(model);
            if(vm != null)
            {
                string sessionObj = JsonSerializer.Serialize(vm);
                HttpContext.Session.SetString("loginDetails", sessionObj);
                return RedirectToUser(vm);
            }
            return View(model);
        }

        private IActionResult RedirectToUser(LoginViewModel vm)
        {
            if(vm.Role == (int)EnumRoles.Admin)
            {
                return RedirectToAction("Index", "Users");
            }else if(vm.Role == (int)EnumRoles.Teacher)
            {
                return RedirectToAction("Index", "Exams");
            }
            else
            {
                return RedirectToAction("Index", "Students");
            }
        }
    }
}
