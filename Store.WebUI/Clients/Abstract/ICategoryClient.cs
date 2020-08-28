using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface ICategoryClient
    {
        Task<List<CategoryDTO>> GetAll();
        Task<CategoryDTO> Get(int Id);
        Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);
        Task<string> Delete(string Id);
    }
}
