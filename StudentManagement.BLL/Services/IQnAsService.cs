using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Services
{
    public interface IQnAsService
    {
        void AddQnAs(CreateQnAsViewModel viewModel);
        PagedResult<QnAsViewModel> GetAll(int pageNumber,  int pageSize);
    }
} 
    