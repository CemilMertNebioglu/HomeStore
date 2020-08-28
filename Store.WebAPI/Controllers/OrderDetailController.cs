using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.Abstract;
using Store.DTO;

namespace Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderdetailservice;
        public OrderDetailController(IOrderDetailService orderdetailservice)
        {
            _orderdetailservice = orderdetailservice;
        }
        [HttpGet]
        [Route("action")]

        public List<OrderDetailDTO> GetAll()
        {
            return _orderdetailservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<OrderDetailDTO> GetAsync(int id)
        {
            return _orderdetailservice.getOrderDetailAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public OrderDetailDTO Get(int id)
        {
            return _orderdetailservice.getOrderDetail(id);
        }
        [HttpPost]
        [Route("action")]

        public OrderDetailDTO Add(OrderDetailDTO dto)
        {
            return _orderdetailservice.addOrderDetail(dto);

        }
        [HttpPut]
        [Route("action")]

        public OrderDetailDTO Update(OrderDetailDTO dto)
        {
            return _orderdetailservice.updateOrderDetail(dto);

        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _orderdetailservice.deleteOrderDetail(id);
        }

    }
}