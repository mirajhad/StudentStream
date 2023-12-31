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
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddStudentAsync(CreateStudentViewModel vm)
        {
            try
            {
                Student obj = vm.ConvertToModel(vm);
              await  _unitOfWork.GenericRepository<Student>().AddAsync(obj);
                _unitOfWork.Save();
                return 1;
            }
            catch (Exception)
            {
               
                throw;
            }

           

        }

        public IEnumerable<StudentsViewModel> GetAll()
        {
            try
            {
                var students = _unitOfWork.GenericRepository<Student>().GetAll().ToList();
                List<StudentsViewModel> studentsViewModelList = new List<StudentsViewModel>();
                studentsViewModelList = ListInfo(students);
                return studentsViewModelList;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private List<StudentsViewModel> ListInfo(List<Student> studentsList)
        {
            return studentsList.Select(x => new StudentsViewModel(x)).ToList();
        }
    }
}
