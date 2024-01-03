using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Services
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(CreateStudentViewModel vm);
        IEnumerable<StudentsViewModel> GetAll();
        IEnumerable<ResultViewModel> GetExamResults(int studentId);
        bool SetExamResult(AttendExamViewModel viewModel);
        bool SetGroupIdToStudent(GroupStudentViewModel viewModel);
    }
}
