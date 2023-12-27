using StudentManagement.Data.Entities;
using StudentManagement.Data.UnitOfWork;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddTeacher(UserViewModel vm)
        {
            try
            {
                Users model = new Users
                {
                    Name = vm.Name,
                    UserName = vm.UserName,
                    Password = vm.Password,
                    Role = (int)EnumRoles.Teacher
                };
                _unitOfWork.GenericRepository<Users>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public LoginViewModel Login(LoginViewModel loginViewModel)
        {

            var user = _unitOfWork.GenericRepository<Users>()
               .GetAll()
               .FirstOrDefault(a => a.UserName == loginViewModel.UserName.Trim()
               && a.Password == loginViewModel.Password
               && a.Role == loginViewModel.Role);
            if (user != null)
            {
                loginViewModel.Id = user.Id;
                return loginViewModel;
            }
            return null;

        }
    }
}
