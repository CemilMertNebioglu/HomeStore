using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IDepartmentService : IServiceBase
    {
        List<DepartmentDTO> getAll();
        DepartmentDTO getDepartment(int departmentId);
        Task<DepartmentDTO> getDepartmentAsync(int departmentId);

        DepartmentDTO addDepartment(DepartmentDTO department);
        DepartmentDTO updateDepartment(DepartmentDTO department);
        bool deleteDepartment(int departmentId);
    }
}
