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
    public class ProductSuppliersController : ControllerBase
    {
        private readonly IProductSupplierService _productSupplierService;
        public ProductSuppliersController(IProductSupplierService productSupplierService)
        {
            _productSupplierService = productSupplierService;
        }
        [HttpGet]
        [Route("action")]

        public List<ProductSupplierDTO> GetAll()
        {
            return _productSupplierService.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<ProductSupplierDTO> GetAsync(int id)
        {
            return _productSupplierService.getPsAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public ProductSupplierDTO Get(int id)
        {
            return _productSupplierService.getPs(id);
        }
        [HttpPost]
        [Route("action")]

        public ProductSupplierDTO Add(ProductSupplierDTO productSupplier)
        {
            return _productSupplierService.addPs(productSupplier);
        }
        [HttpPut]
        [Route("action")]

        public ProductSupplierDTO Update(ProductSupplierDTO productSupplier)
        {
            return _productSupplierService.updateaddPs(productSupplier);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _productSupplierService.deletePs(id);
        }
    }
}