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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentsController(IDepartmentService departmentservice)
        {
            _departmentservice = departmentservice;
        }
        [HttpGet]
        public List<DepartmentDTO> GetAll()
        {
            return _departmentservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<DepartmentDTO> GetAsync(int id)
        {
            return _departmentservice.getDepartmentAsync(id);

        }
        [HttpGet]
        [Route("action")]
        public DepartmentDTO Get(int id)
        {
            return _departmentservice.getDepartment(id);
        }
        [HttpPost]
        [Route("action")]

        public DepartmentDTO Add(DepartmentDTO dto)
        {
            return _departmentservice.addDepartment(dto);
        }
        [HttpPut]
        [Route("action")]

        public DepartmentDTO Update(DepartmentDTO dto)
        {
            return _departmentservice.updateDepartment(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _departmentservice.deleteDepartment(id);
        }
    }
}