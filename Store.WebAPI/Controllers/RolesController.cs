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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _userservice;
        public RolesController(IRoleService userservice)
        {
            _userservice = userservice;
        }
        [HttpGet]
        [Route("action")]

        public List<RoleDTO> GetAll()
        {
            return _userservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<RoleDTO> GetAsync(int id)
        {
            return _userservice.getUserAsync(id);
        }
        [HttpGet]
        [Route("action")]
        public RoleDTO Get(int id)
        {
            return _userservice.getUser(id);
        }
        [HttpPost]
        [Route("action")]

        public RoleDTO Add(RoleDTO dto)
        {
            return _userservice.addUser(dto);
        }
        [HttpPut]
        [Route("action")]

        public RoleDTO Update(RoleDTO dto)
        {
            return _userservice.updateUser(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _userservice.deleteUser(id);
        }
    }
}
