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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierservice;
        public SuppliersController(ISupplierService supplierservice)
        {
            _supplierservice = supplierservice;
        }
        [HttpGet]
        [Route("action")]

        public List<SupplierDTO> GetAll()
        {
            return _supplierservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<SupplierDTO> GetAsync(int id)
        {
            return _supplierservice.getSupplierAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public SupplierDTO Get(int id)
        {
            return _supplierservice.getSupplier(id);
        }
        [HttpPost]
        [Route("action")]

        public SupplierDTO Add(SupplierDTO dto)
        {
            return _supplierservice.addSupplier(dto);
        }
        [HttpPut]
        [Route("action")]

        public SupplierDTO Update(SupplierDTO dto)
        {
            return _supplierservice.updateSupplier(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _supplierservice.deleteSupplier(id);
        }
    }
}