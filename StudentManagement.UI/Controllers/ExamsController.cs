using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.UI.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
