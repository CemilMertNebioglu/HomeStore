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
    public class DealerService : IDealerService
    {
        private readonly IUnitofWork _uow;
        public DealerService(IUnitofWork uow)
        {
            _uow = uow;
            
        }
        public DealerDTO addDealer(DealerDTO dealer)
        {
            //Test commit
            if (!_uow.GetRepository<Dealer>().GetAll().Any(z=> z.CompanyName == dealer.CompanyName))
            {
                var addDealer = MapperFactory.CurrentMapper.Map<Dealer>(dealer);
                addDealer = _uow.GetRepository<Dealer>().Add(addDealer);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DealerDTO>(addDealer);
            }
            else
            {
                return null;
            }
        }

        public bool deleteDealer(int dealerId)
        {
            try
            {
                var delete = _uow.GetRepository<Dealer>().Get(z => z.Id == dealerId);
                _uow.GetRepository<Dealer>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<DealerDTO> getAll()
        {
            var list=_uow.GetRepository<Dealer>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<DealerDTO>>(list);
        }

        public DealerDTO getDealer(int dealerId)
        {
            var dealer = _uow.GetRepository<Dealer>().Get(z => z.Id == dealerId);
            return MapperFactory.CurrentMapper.Map<DealerDTO>(dealer);
        }   

        public async Task<DealerDTO> getDealerAsync(int dealerId)
        {
            var dealer = await _uow.GetRepository<Dealer>().GetAsync(z => z.Id == dealerId);
            return MapperFactory.CurrentMapper.Map<DealerDTO>(dealer);
        }

        public DealerDTO updateDealer(DealerDTO dealer)
        {
            var update = _uow.GetRepository<Dealer>().Get(z => z.Id == dealer.Id);
            update = MapperFactory.CurrentMapper.Map<Dealer>(update);
            _uow.GetRepository<Dealer>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DealerDTO>(update);
        }
    }
}
