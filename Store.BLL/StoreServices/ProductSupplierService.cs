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
    public class ProductSupplierService : IProductSupplierService
    {
        private readonly IUnitofWork _uow;
        public ProductSupplierService(IUnitofWork uow)
        {
            _uow = uow;
        }
        public ProductSupplierDTO addPs(ProductSupplierDTO productsupplier)
        {
            var add = MapperFactory.CurrentMapper.Map<ProductSupplier>(productsupplier);
            _uow.GetRepository<ProductSupplier>().Add(add);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ProductSupplierDTO>(add);
        }

        public bool deletePs(int productsupplierId)
        {
            try
            {
                var delete = _uow.GetRepository<ProductSupplier>().Get(z => z.Id == productsupplierId);
                _uow.GetRepository<ProductSupplier>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ProductSupplierDTO> getAll()
        {
            var list = _uow.GetRepository<ProductSupplier>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ProductSupplierDTO>>(list);
        }

        public ProductSupplierDTO getPs(int productsupplierId)
        {
            var productsupplier = _uow.GetRepository<ProductSupplier>().Get(z => z.Id == productsupplierId);
            return MapperFactory.CurrentMapper.Map<ProductSupplierDTO>(productsupplier);
        }

        public  async Task<ProductSupplierDTO> getPsAsync(int productsupplierId)
        {
            var productsupplier =await _uow.GetRepository<ProductSupplier>().GetAsync(z => z.Id == productsupplierId);
            return MapperFactory.CurrentMapper.Map<ProductSupplierDTO>(productsupplier);
        }

        public ProductSupplierDTO updateaddPs(ProductSupplierDTO productsupplier)
        {
            var update = _uow.GetRepository<ProductSupplier>().Get(z => z.Id == productsupplier.Id);
            update = MapperFactory.CurrentMapper.Map<ProductSupplier>(productsupplier);
            _uow.GetRepository<ProductSupplier>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ProductSupplierDTO>(update);
        }
    }
}
