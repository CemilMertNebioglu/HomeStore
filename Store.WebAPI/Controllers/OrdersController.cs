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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        public OrdersController(IOrderService orderservice)
        {
            _orderservice = orderservice;
        }
        [HttpGet]
        [Route("action")]

        public List<OrderDTO> GetAll()
        {
            return _orderservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<OrderDTO> GetAsync(int id)
        {
            return _orderservice.getOrdersAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public OrderDTO Get(int id)
        {
            return _orderservice.getOrder(id);
        }
        [HttpPost]
        [Route("action")]

        public OrderDTO Add(OrderDTO dto)
        {
            return _orderservice.addOrder(dto);
        }
        [HttpPut]
        public OrderDTO Update(OrderDTO dto)
        {
            return _orderservice.updateOrder(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _orderservice.deleteOrder(id);
        }

    }
}