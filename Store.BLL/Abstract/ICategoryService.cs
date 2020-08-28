using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
    public interface ICategoryService : IServiceBase
    {
        Task<List<CategoryDTO>> getAll();
        CategoryDTO getCategory(int categoryId);
        Task<CategoryDTO> getCategoryAsync(int categoryId);
        CategoryDTO addCategory(CategoryDTO category);

        CategoryDTO updateCategory(CategoryDTO category);
        bool deleteCategory(int categoryId);
    }
}
