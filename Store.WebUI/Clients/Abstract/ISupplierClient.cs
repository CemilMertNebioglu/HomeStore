using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface ISupplierClient
    {
        Task<List<SupplierDTO>> GetAll();
        Task<SupplierDTO> Get(int Id);
        Task<SupplierDTO> AddSupplier(SupplierDTO dto);
        Task<SupplierDTO> UpdateSupplier(SupplierDTO dto);
        Task<string> Delete(string Id);
    }
}
