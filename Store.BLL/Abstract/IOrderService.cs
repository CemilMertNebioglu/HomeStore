using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IOrderService : IServiceBase
    {
        List<OrderDTO> getAll();
        OrderDTO getOrder(int orderId);
        Task<OrderDTO> getOrdersAsync(int orderId);
        OrderDTO addOrder(OrderDTO order);
        OrderDTO updateOrder(OrderDTO order);
        bool deleteOrder(int orderId);
        //TODO: Kontrol edilecek.
    }
}
