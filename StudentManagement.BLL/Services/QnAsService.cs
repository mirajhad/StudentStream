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
    public class QnAsService : IQnAsService
    {
        private IUnitOfWork _unitOfWork;

        public QnAsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddQnAs(CreateQnAsViewModel viewModel)
         {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<QnAs>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<QnAsViewModel> qnAsViewModel = new List<QnAsViewModel>();

                var groupList = _unitOfWork.GenericRepository<QnAs>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();

                qnAsViewModel = ListInfo(groupList);
                var result = new PagedResult<QnAsViewModel>
                {
                    Data = qnAsViewModel,
                    TotalItems = _unitOfWork.GenericRepository<QnAs>()
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

        private List<QnAsViewModel> ListInfo(List<QnAs> modelList)
        {
            return modelList.Select(x => new QnAsViewModel(x)).ToList();
        }
    }
}
