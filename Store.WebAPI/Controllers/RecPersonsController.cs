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
    public class RecPersonsController : ControllerBase
    {
        private readonly IRecPersonService _recpersonservice;
        public RecPersonsController(IRecPersonService recpersonservice)
        {
            _recpersonservice = recpersonservice;
        }
        [HttpGet]
        [Route("action")]

        public List<RecPersonDTO> GetAll()
        {
            return _recpersonservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<RecPersonDTO> GetAsync(int id)
        {
            return _recpersonservice.getRecPersonAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public RecPersonDTO Get(int id)
        {
            return _recpersonservice.getRecPerson(id);
        }
        [HttpPost]
        [Route("action")]

        public RecPersonDTO Add(RecPersonDTO dto)
        {
            return _recpersonservice.addRecPerson(dto);
        }
        [HttpPut]
        [Route("action")]

        public RecPersonDTO Update(RecPersonDTO dto)
        {
            return _recpersonservice.updateRecPerson(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _recpersonservice.deleteRecPerson(id);
        }
    }
}