using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
    public interface IOrderDetailService  : IServiceBase
    {
        List<OrderDetailDTO> getAll();
        OrderDetailDTO getOrderDetail(int orderdetailId);
        Task<OrderDetailDTO> getOrderDetailAsync(int orderdetailId);
        OrderDetailDTO addOrderDetail(OrderDetailDTO orderDetail);
        OrderDetailDTO updateOrderDetail(OrderDetailDTO orderDetail);
        bool deleteOrderDetail(int orderdetailId);

    }
}
