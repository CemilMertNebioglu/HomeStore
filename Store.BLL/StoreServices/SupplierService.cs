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
    public class SupplierService : ISupplierService
    {
        private readonly IUnitofWork _uow;
        public SupplierService(IUnitofWork uow)
        {
            _uow = uow;
          
        }
        public SupplierDTO addSupplier(SupplierDTO supplier)
        {
            if (!_uow.GetRepository<Supplier>().GetAll().Any(z=> z.CompanyName == supplier.CompanyName))
            {
                var add = MapperFactory.CurrentMapper.Map<Supplier>(supplier);
                _uow.GetRepository<Supplier>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SupplierDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteSupplier(int supplierId)
        {
            try
            {
                var delete = _uow.GetRepository<Supplier>().Get(z => z.Id == supplierId);
                _uow.GetRepository<Supplier>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SupplierDTO> getAll()
        {
            var list = _uow.GetRepository<Supplier>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<SupplierDTO>>(list);
        }

        public SupplierDTO getSupplier(int supplierId)
        {
            var supplier = _uow.GetRepository<Supplier>().Get(z => z.Id == supplierId);
            return MapperFactory.CurrentMapper.Map<SupplierDTO>(supplier);
        }

        public async Task<SupplierDTO> getSupplierAsync(int supplierId)
        {
            var supplier =await _uow.GetRepository<Supplier>().GetAsync(z => z.Id == supplierId);
            return MapperFactory.CurrentMapper.Map<SupplierDTO>(supplier);
        }

        public SupplierDTO updateSupplier(SupplierDTO supplier)
        {
            var update = _uow.GetRepository<Supplier>().Get(z => z.Id == supplier.Id);
            update = MapperFactory.CurrentMapper.Map<Supplier>(supplier);
            _uow.GetRepository<Supplier>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SupplierDTO>(update);
        }
    }
}
