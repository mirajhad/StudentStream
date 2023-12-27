using Microsoft.AspNetCore.Mvc;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI.Controllers
{
    public class GroupsController : Controller
    {
        private IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
