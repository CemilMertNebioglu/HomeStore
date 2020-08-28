using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IProductClient
    {
        Task<List<ProductDTO>> GetAll();
        Task<ProductDTO> Get(int Id);
        Task<ProductDTO> AddProduct(ProductDTO dto);
        Task<ProductDTO> UpdateProduct(ProductDTO dto);
        Task<string> Delete(string Id);
    }
}
