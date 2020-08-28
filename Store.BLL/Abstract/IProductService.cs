using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IProductService : IServiceBase
    {
        List<ProductDTO> getAll();

        ProductDTO getProduct(int productId);
        Task<ProductDTO> getProductAsync(int productId);
        ProductDTO addProduct(ProductDTO product);
        ProductDTO updateProduct(ProductDTO product);
        bool deleteProduct(int productId);
    }
}
