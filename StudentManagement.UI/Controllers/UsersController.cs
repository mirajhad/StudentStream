using Microsoft.AspNetCore.Mvc;
using StudentManagement.BLL.Services;
using StudentManagement.Models;

namespace StudentManagement.UI.Controllers
{
    public class UsersController : Controller
    {
        private IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index(int pageNumber, int pageSize)
        {
            return View(_accountService.GetAllTeacher(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel vm)
        {
            bool success = _accountService.AddTeacher(vm);
            if(success)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
