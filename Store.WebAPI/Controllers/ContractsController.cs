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
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractservice;
        public ContractsController(IContractService contractservice)
        {
            _contractservice = contractservice;
        }
        [HttpGet]
        [Route("action")]

        public List<ContractDTO> GetAll()
        {
            return _contractservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<ContractDTO> GetAsync(int id)
        {
            return _contractservice.getContractAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public ContractDTO Get(int id)
        {
            return _contractservice.getContract(id);
        }
        [HttpPost]
        [Route("action")]
        public ContractDTO Add(ContractDTO contract)
        {
            return _contractservice.addContract(contract);
        }
        [HttpPut]
        [Route("action")]

        public ContractDTO Update(ContractDTO contract)
        {
            return _contractservice.updateContract(contract);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _contractservice.deleteContract(id);
        }
    }
}