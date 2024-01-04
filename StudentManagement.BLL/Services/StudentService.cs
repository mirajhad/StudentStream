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

        public PagedResult<StudentViewModel> GetAllStudents(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<StudentViewModel> studentViewModel = new List<StudentViewModel>();

                var studentList = _unitOfWork.GenericRepository<Student>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();

                studentViewModel = ConvertToStudentVM(studentList);
                var result = new PagedResult<StudentViewModel>
                {
                    Data = studentViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Student>()
                    .GetAll()
                    .Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<StudentViewModel> ConvertToStudentVM(List<Student> studentList)
        {
            return studentList.Select(x => new StudentViewModel(x)).ToList();
        }

        public IEnumerable<ResultViewModel> GetExamResults(int studentId)
        {
            throw new NotImplementedException();
        }

        public bool SetExamResult(AttendExamViewModel viewModel)
        {
            try
            {
                foreach (var item in viewModel.QnAsList)
                {
                    ExamResults result = new ExamResults();
                    result.StudentId = viewModel.StudentId;
                    result.ExamId = item.ExamsId;
                    //result.QnAsId = item.Id;
                    result.Answer = item.Answer;
                    _unitOfWork.GenericRepository<ExamResults>().Add(result);
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool SetGroupIdToStudent(GroupStudentViewModel viewModel)
        {
            try
            {
                foreach (var item in viewModel.StudentList)
                {
                    var student = _unitOfWork.GenericRepository<Student>().GetById(item.Id);
                    if (item.IsChecked)
                    {
                        student.GroupsId = viewModel.GroupId;
                        _unitOfWork.GenericRepository<Student>().Update(student);
                    }
                    else
                    {
                        student.GroupsId = null;
                    }
                }
                _unitOfWork.Save();
                return true;
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
