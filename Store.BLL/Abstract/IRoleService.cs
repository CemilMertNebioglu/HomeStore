using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
    public interface IRoleService : IServiceBase
    {
        List<RoleDTO> getAll();
        RoleDTO getUser(int userId);
        Task<RoleDTO> getUserAsync(int userId);
        RoleDTO addUser(RoleDTO user);
        RoleDTO updateUser(RoleDTO user);
        bool deleteUser(int userId);
    }
}
