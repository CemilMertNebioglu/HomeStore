using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.Abstract;
using Store.DTO;

namespace Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //TODO: Route yapılacak
        [HttpGet]
        [Route("action")]
        public async Task<List<CategoryDTO>> GetAll()
        {
            return await _categoryService.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]
        public Task<CategoryDTO> GetAsync(int id)
        {
            return _categoryService.getCategoryAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public CategoryDTO Get(int id)
        {
            return _categoryService.getCategory(id);
        }
        [HttpPost]
        [Route("action")]

        public CategoryDTO Add (CategoryDTO category)
        {
            return _categoryService.addCategory(category);
        }
        [HttpPut]
        [Route("action")]

        public CategoryDTO Update(CategoryDTO category)
        {
            return _categoryService.updateCategory(category);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _categoryService.deleteCategory(id);
        }
    }
}