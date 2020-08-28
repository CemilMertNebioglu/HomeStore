using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IOrderDetailClient
    {
        Task<List<OrderDetailDTO>> GetAll();
        Task<OrderDetailDTO> Get(int Id);
        Task<OrderDetailDTO> AddOrderDetail(OrderDetailDTO dto);
        Task<OrderDetailDTO> UpdateOrderDetail(OrderDetailDTO dto);
        Task<string> Delete(string Id);
    }
}
