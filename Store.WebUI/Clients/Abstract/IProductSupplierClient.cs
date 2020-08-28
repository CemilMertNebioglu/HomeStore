using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IProductSupplierClient
    {
        Task<List<ProductSupplierDTO>> GetAll();
        Task<ProductSupplierDTO> Get(int Id);
        Task<ProductSupplierDTO> AddProductSupplier(ProductSupplierDTO dto);
        Task<ProductSupplierDTO> UpdateProductSupplier(ProductSupplierDTO dto);
        Task<string> Delete(string Id);
    }
}
