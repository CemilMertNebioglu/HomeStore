using Microsoft.EntityFrameworkCore;
using Store.BLL.Abstract;
using Store.Core.Data.UnitofWork;
using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.StoreServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork uow;
        public CategoryService(IUnitofWork _uow)
        {
            uow = _uow;
           
        }
        public bool deleteCategory(int categoryId)
        {
            try
            {
                var category = uow.GetRepository<Category>().Get(z => z.Id == categoryId);
                uow.GetRepository<Category>().Delete(category);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)//TODO: Kendi custom exceptionını yaz.
            {
                return false;
            }
        }

        public async Task<List<CategoryDTO>> getAll()
        {
            var categoryList = await uow.GetRepository<Category>().GetAll().ToListAsync();
            return MapperFactory.CurrentMapper.Map<List<CategoryDTO>>(categoryList);
        }

        public CategoryDTO getCategory(int categoryId)
        {
            var category = uow.GetRepository<Category>().Get(z => z.Id == categoryId);
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> getCategoryAsync(int categoryId)
        {
            var category = await uow.GetRepository<Category>().GetAsync(z => z.Id == categoryId);
            //var ss = uow.GetRepository<Category>().Get(x => x.Id == categoryId, x => x.Products);
            //var tt = uow.GetRepository<Category>().GetIncludes(x => x.Id == categoryId,x => x.Products, x=> x.Description);
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO addCategory(CategoryDTO category)
        {
            if (!uow.GetRepository<Category>().GetAll().Any(z => z.CategoryName == category.CategoryName)) // TODO: büyük küçük harf uyumsuzluğunu ignorelayan methodu kullan
            {
                var added = MapperFactory.CurrentMapper.Map<Category>(category);
                added = uow.GetRepository<Category>().Add(added);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CategoryDTO>(added);
            }
            else
            {
                return null;
            }
        }

        public CategoryDTO updateCategory(CategoryDTO category)
        {
            var updated = uow.GetRepository<Category>().Get(z => z.Id == category.Id);
            updated = MapperFactory.CurrentMapper.Map<Category>(category);
            uow.GetRepository<Category>().Update(updated);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CategoryDTO>(updated);
        }

        //TODO: WEBAPI startup.cs
        //CONFIGURE SERVICES 
        //services.addTransient<ICategoryService,CategoryService>();


        //CategoryController
        //private readonly  ICategoryService _categoryService
        //
        //ctor => _categoryService = categoryService
        //
        //async Task<CategoryDTO> GetCategory(id)
        //
        // return await _categoryService.GetCategoryAsync(id);
        //

    }
}
