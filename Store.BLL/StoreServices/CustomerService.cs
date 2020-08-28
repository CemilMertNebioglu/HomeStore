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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork _uow;
        public CustomerService(IUnitofWork uow)
        {
            _uow = uow;
           
        }
        public bool deleteCustomer(int customerId)
        {
            try
            {
                var customer = _uow.GetRepository<Customer>().Get(z => z.Id == customerId);
                _uow.GetRepository<Customer>().Delete(customer);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<CustomerDTO> getAll()
        {
            var customerList = _uow.GetRepository<Customer>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CustomerDTO>>(customerList);
        }

        public async Task<CustomerDTO> getCustomerAsync(int customerId)
        {
            var customer = await _uow.GetRepository<Customer>().GetAsync(z => z.Id == customerId);
            return MapperFactory.CurrentMapper.Map<CustomerDTO>(customer);

        }

        public CustomerDTO getCustomer(int customerId)
        {
            var customer = _uow.GetRepository<Customer>().Get(z => z.Id == customerId);
            return MapperFactory.CurrentMapper.Map<CustomerDTO>(customer);
        }

        public CustomerDTO addCustomer(CustomerDTO customer)
        {
            if (!_uow.GetRepository<Customer>().GetAll().Any(z => z.Phone == customer.Phone))
            {
                var addCustomer = MapperFactory.CurrentMapper.Map<Customer>(customer);
                _uow.GetRepository<Customer>().Add(addCustomer);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CustomerDTO>(addCustomer);
            }
            else
            {
                return null;
            }
        }

        public CustomerDTO updateCustomer(CustomerDTO customer)
        {
            var update = _uow.GetRepository<Customer>().Get(z => z.Id == customer.Id);
            update = MapperFactory.CurrentMapper.Map<Customer>(customer);
            _uow.GetRepository<Customer>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CustomerDTO>(update);

        }
    }
}
