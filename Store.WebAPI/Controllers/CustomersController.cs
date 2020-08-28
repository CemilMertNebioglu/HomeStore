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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerservice;
        public CustomersController(ICustomerService customerservice)
        {
            _customerservice = customerservice;
        }
        [HttpGet]
        public List<CustomerDTO> GetAll()
        {
            return _customerservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<CustomerDTO> GetAsync(int id)
        {
            return _customerservice.getCustomerAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public CustomerDTO Get(int id)
        {
            return _customerservice.getCustomer(id);
        }
        [HttpPost]
        [Route("action")]

        public CustomerDTO Add(CustomerDTO dto)
        {
            return _customerservice.addCustomer(dto);
        }
        [HttpPut]
        [Route("action")]

        public CustomerDTO Update(CustomerDTO dto)
        {
            return _customerservice.updateCustomer(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _customerservice.deleteCustomer(id);
        }


    }
}