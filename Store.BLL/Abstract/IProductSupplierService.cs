using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IProductSupplierService : IServiceBase
    {
        List<ProductSupplierDTO> getAll();
        ProductSupplierDTO getPs(int productsupplierId);
        Task<ProductSupplierDTO> getPsAsync(int productsupplierId);
        ProductSupplierDTO addPs(ProductSupplierDTO productsupplier);

        ProductSupplierDTO updateaddPs(ProductSupplierDTO productsupplier);
        bool deletePs(int productsupplierId);
    }
}
