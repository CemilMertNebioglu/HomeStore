using Store.BLL.Abstract;
using Store.Core.Data.UnitofWork;
using Store.DTO;
using Store.Mapping.ConfigProfile;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.StoreServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork _uow;
        public RoleService(IUnitofWork uow)
        {
            _uow = uow;
          
        }
        public RoleDTO addUser(RoleDTO user)
        {
            if (!_uow.GetRepository<Role>().GetAll().Any(z=> z.Name == user.Name))
            {
                var add = MapperFactory.CurrentMapper.Map<Role>(user);
                _uow.GetRepository<Role>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteUser(int userId)
        {
            try
            {
                var delete = _uow.GetRepository<Role>().Get(z => z.Id == userId);
                _uow.GetRepository<Role>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false; 
            }
        }

        public List<RoleDTO> getAll()
        {
            var list = _uow.GetRepository<Role>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(list);
        }

        public async Task<RoleDTO> getUserAsync(int userId)
        {
            var user = await _uow.GetRepository<Role>().GetAsync(z => z.Id == userId);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(user);
        }

        public RoleDTO getUser(int userId)
        {
            var user = _uow.GetRepository<Role>().Get(z => z.Id == userId);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(user);
        }

        public RoleDTO updateUser(RoleDTO user)
        {
            var update = _uow.GetRepository<Role>().Get(z => z.Id == user.Id);
            update = MapperFactory.CurrentMapper.Map<Role>(user);
            _uow.GetRepository<Role>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(update);
          
        }
    }
}
