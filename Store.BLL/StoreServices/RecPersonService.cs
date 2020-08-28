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
    public class RecPersonService : IRecPersonService
    {
        private readonly IUnitofWork _uow;
        public RecPersonService(IUnitofWork uow)
        {
            _uow = uow;
            
        }
        public RecPersonDTO addRecPerson(RecPersonDTO recPerson)
        {
            if (!_uow.GetRepository<RecPerson>().GetAll().Any(z=> z.Cv == recPerson.Cv))
            {
                var add = MapperFactory.CurrentMapper.Map<RecPerson>(recPerson);
                 _uow.GetRepository<RecPerson>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RecPersonDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteRecPerson(int recpersonId)
        {
            try
            {
                var delete = _uow.GetRepository<RecPerson>().Get(z => z.Id == recpersonId);
                _uow.GetRepository<RecPerson>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<RecPersonDTO> getAll()
        {
            var list = _uow.GetRepository<RecPerson>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<RecPersonDTO>>(list);
        }

        public RecPersonDTO getRecPerson(int recpersonId)
        {
            var recPerson = _uow.GetRepository<RecPerson>().Get(z => z.Id == recpersonId);
            return MapperFactory.CurrentMapper.Map<RecPersonDTO>(recPerson);
        }

        public async Task<RecPersonDTO> getRecPersonAsync(int recpersonId)
        {
            var recPerson =await _uow.GetRepository<RecPerson>().GetAsync(z => z.Id == recpersonId);
            return MapperFactory.CurrentMapper.Map<RecPersonDTO>(recPerson);
        }

        public RecPersonDTO updateRecPerson(RecPersonDTO recPerson)
        {
            var update = _uow.GetRepository<RecPerson>().Get(z => z.Id == recPerson.Id);
            update = MapperFactory.CurrentMapper.Map<RecPerson>(recPerson);
            _uow.GetRepository<RecPerson>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RecPersonDTO>(update);
        }
    }

    
}
