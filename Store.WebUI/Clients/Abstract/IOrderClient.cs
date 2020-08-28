using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IOrderClient
    {
        Task<List<OrderDTO>> GetAll();
        Task<OrderDTO> Get(int Id);
        Task<OrderDTO> AddOrder(OrderDTO dto);
        Task<OrderDTO> UpdateOrder(OrderDTO dto);
        Task<string> Delete(string Id);
    }
}
