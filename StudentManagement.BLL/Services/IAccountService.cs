using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Services
{
    public interface IAccountService
    {
        bool AddTeacher(UserViewModel vm);
        LoginViewModel Login(LoginViewModel loginViewModel);
        PagedResult<TeacherViewModel> GetAllTeacher(int pageNumber, int PageSize);
    }
}
