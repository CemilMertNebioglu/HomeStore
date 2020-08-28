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
    public class ProductService : IProductService
    {
        private readonly IUnitofWork _uow;
        public ProductService(IUnitofWork uow)
        {
            _uow = uow;
          
        }
        public ProductDTO addProduct(ProductDTO product)
        {
            if (!_uow.GetRepository<Product>().GetAll().Any(z=> z.ProductName == product.ProductName))
            {
                var add = MapperFactory.CurrentMapper.Map<Product>(product);
                add = _uow.GetRepository<Product>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ProductDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteProduct(int productId)
        {
            try
            {
                var delete = _uow.GetRepository<Product>().Get(z => z.Id == productId);
                _uow.GetRepository<Product>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ProductDTO> getAll()
        {
            var list = _uow.GetRepository<Product>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ProductDTO>>(list);
        }

        public ProductDTO getProduct(int productId)
        {
            var product = _uow.GetRepository<Product>().Get(z => z.Id == productId);
            return MapperFactory.CurrentMapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> getProductAsync(int productId)
        {
            var product =await _uow.GetRepository<Product>().GetAsync(z => z.Id == productId);
            return MapperFactory.CurrentMapper.Map<ProductDTO>(product);
        }

        public ProductDTO updateProduct(ProductDTO product)
        {
            var update = _uow.GetRepository<Product>().Get(z => z.Id == product.Id);
            update = MapperFactory.CurrentMapper.Map<Product>(product);
            _uow.GetRepository<Product>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ProductDTO>(update);
        }
    }
}
