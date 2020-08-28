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
    public class DealersController : ControllerBase
    {
        private readonly IDealerService _dealerservice;
        public DealersController(IDealerService dealerservice)
        {
            _dealerservice = dealerservice;
        }
        [HttpGet]
        [Route("action")]

        public List<DealerDTO> GetAll()
        {
            return _dealerservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<DealerDTO> GetAsync(int id)
        {
            return _dealerservice.getDealerAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public DealerDTO Get(int id)
        {
            return _dealerservice.getDealer(id);
        }
        [HttpPut]
        [Route("action")]

        public DealerDTO Update(DealerDTO dto)
        {
            return _dealerservice.updateDealer(dto);
        }
        [HttpPost]
        [Route("action")]

        public DealerDTO Add (DealerDTO dto)
        {
            return _dealerservice.addDealer(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _dealerservice.deleteDealer(id);
        }
         
    }
}