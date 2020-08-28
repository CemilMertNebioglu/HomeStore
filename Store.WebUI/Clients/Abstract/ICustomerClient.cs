using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{

    public interface ICustomerClient
    {
        Task<List<CustomerDTO>> GetAll();
        Task<CustomerDTO> Get(int Id);
        Task<CustomerDTO> AddCustomer(CustomerDTO dto);
        Task<CustomerDTO> UpdateCustomer(CustomerDTO dto);
        Task<string> Delete(string Id);
    }

}
