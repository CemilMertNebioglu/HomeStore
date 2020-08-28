using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IRoleClient

    {
        Task<List<RoleDTO>> GetAll();
        Task<RoleDTO> Get(int Id);
        Task<RoleDTO> AddRole(RoleDTO dto);
        Task<RoleDTO> UpdateRole(RoleDTO dto);
        Task<string> Delete(string Id);
    }
}
