using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IDepartmentClient
    {
        Task<List<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> Get(int Id);
        Task<DepartmentDTO> AddDepartment(DepartmentDTO dto);
        Task<DepartmentDTO> UpdateDepartment(DepartmentDTO dto);
        Task<string> Delete(string Id);
    }
}
