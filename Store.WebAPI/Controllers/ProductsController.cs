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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }
        [HttpGet]
        [Route("action")]

        public List<ProductDTO> GetAll()
        {
            return _productservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<ProductDTO> GetAsync(int id)
        {
            return _productservice.getProductAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public ProductDTO Get(int id)
        {
            return _productservice.getProduct(id);
        }
        [HttpPost]
        [Route("action")]

        public ProductDTO Add(ProductDTO dto)
        {
            return _productservice.addProduct(dto);
        }
        [HttpPut]
        [Route("action")]

        public ProductDTO Update(ProductDTO dto)
        {
            return _productservice.updateProduct(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _productservice.deleteProduct(id);
        }
    }
}