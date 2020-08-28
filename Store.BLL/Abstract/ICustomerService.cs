using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface ICustomerService : IServiceBase
    {
        List<CustomerDTO> getAll();
        CustomerDTO getCustomer(int customerId);
        Task<CustomerDTO> getCustomerAsync(int customerId);

        CustomerDTO addCustomer(CustomerDTO customer);
        CustomerDTO updateCustomer(CustomerDTO customer);
        bool deleteCustomer(int customerId);
    }
}
