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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitofWork _uow;
        public DepartmentService(IUnitofWork uow)
        {
            _uow = uow;
           
        }
        public DepartmentDTO addDepartment(DepartmentDTO department)
        {
            if (!_uow.GetRepository<Department>().GetAll().Any(z=> z.DepartmentName == department.DepartmentName))
            {
                var add = MapperFactory.CurrentMapper.Map<Department>(department);
                add = _uow.GetRepository<Department>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DepartmentDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteDepartment(int departmentId)
        {
            try
            {
                var delete = _uow.GetRepository<Department>().Get(z => z.Id == departmentId);
                _uow.GetRepository<Department>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<DepartmentDTO> getAll()
        {
            var list = _uow.GetRepository<Department>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<DepartmentDTO>>(list);
        }

        public DepartmentDTO getDepartment(int departmentId)
        {
            var department = _uow.GetRepository<Department>().Get(z => z.Id == departmentId);
            return MapperFactory.CurrentMapper.Map<DepartmentDTO>(department);
        }

        public async Task<DepartmentDTO> getDepartmentAsync(int departmentId)
        {
            var department = await _uow.GetRepository<Department>().GetAsync(z => z.Id == departmentId);
            return MapperFactory.CurrentMapper.Map<DepartmentDTO>(department);
        }

        public DepartmentDTO updateDepartment(DepartmentDTO department)
        {
            var update = _uow.GetRepository<Department>().Get(z => z.Id == department.Id);
            update = MapperFactory.CurrentMapper.Map<Department>(department);
            _uow.GetRepository<Department>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DepartmentDTO>(update);
        }
    }
}
