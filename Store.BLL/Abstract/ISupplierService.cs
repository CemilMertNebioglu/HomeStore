using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface ISupplierService : IServiceBase
    {
        List<SupplierDTO> getAll();
        SupplierDTO getSupplier(int supplierId);
        Task<SupplierDTO> getSupplierAsync(int supplierId);

        SupplierDTO addSupplier(SupplierDTO supplier);
        SupplierDTO updateSupplier(SupplierDTO supplier);
        bool deleteSupplier(int supplierId);

    }
}
