using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagement.BLL.Services;
using StudentManagement.Models;

namespace StudentManagement.UI.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;
        private IExamService _examService;
        private IQnAsService _qnAsService;

        public StudentsController(IStudentService studentService, IExamService examService, IQnAsService qnAsService)
        {
            _studentService = studentService;
            _examService = examService;
            _qnAsService = qnAsService;
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var success = await _studentService.AddStudentAsync(vm);
            if (success > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AttendExam()
        {
            var model = new AttendExamViewModel();
            string loginObj = HttpContext.Session.GetString("loginDetails");
            LoginViewModel sessionObj = JsonConvert.DeserializeObject<LoginViewModel>(loginObj);
            if(sessionObj == null)
            {
                model.StudentId = sessionObj.Id;
                var todayExam = _examService.GetAllExams().Where(x => x.StartDate.Date == DateTime.Today.Date).FirstOrDefault();
                if(todayExam == null)
                {
                    model.Message = "No Exam Scheduled Today";
                    return View(model);
                }else
                {
                    if(! _qnAsService.IsAttendExam(todayExam.Id, model.StudentId))
                    {
                        model.QnAsList = _qnAsService.GetAllByExamId(todayExam.Id).ToList();
                        model.ExamName = todayExam.Title;
                        return View(model);
                    }
                    else
                    {
                        model.Message = "You have alreday attended this exam";
                        return View(model);
                    }
                }
            }
            return RedirectToAction("Login", "Accounts");
        }

        [HttpPost]
        public IActionResult AttendExam(AttendExamViewModel viewModel)
        {
            bool result = _studentService.SetExamResult(viewModel);
            return RedirectToAction("");
        }

        //public IActionResult Result(int studentId)
        //{
        //    var model = _studentService.GetExamResults(studentId);
        //}
    }
}
