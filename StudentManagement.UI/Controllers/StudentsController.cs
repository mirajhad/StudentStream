using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
