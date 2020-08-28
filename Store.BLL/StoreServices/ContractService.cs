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
    public class ContractService : IContractService
    {
        private readonly IUnitofWork _uow;
        public ContractService(IUnitofWork uow)
        {
            _uow = uow;
        }
        public ContractDTO addContract(ContractDTO contract)
        {
            if (!_uow.GetRepository<Contract>().GetAll().Any(z=> z.Title == contract.Title))
            {
                var add = MapperFactory.CurrentMapper.Map<Contract>(contract);
                _uow.GetRepository<Contract>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ContractDTO>(add);
            }
            else
            {
                return null;
            }
           
        }

        public bool deleteContract(int contractId)
        {
            try
            {
                var delete = _uow.GetRepository<Contract>().Get(z => z.Id == contractId);
                _uow.GetRepository<Contract>().Delete(delete);
                _uow.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ContractDTO> getAll()
        {
            var list = _uow.GetRepository<Contract>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<ContractDTO>>(list);
        }

        public ContractDTO getContract(int contractId)
        {
            var contract = _uow.GetRepository<Contract>().Get(z => z.Id == contractId);
            return MapperFactory.CurrentMapper.Map<ContractDTO>(contract);
        }

        public async Task<ContractDTO> getContractAsync(int contractId)
        {
            var contract =await _uow.GetRepository<Contract>().GetAsync(z => z.Id == contractId);
            return MapperFactory.CurrentMapper.Map<ContractDTO>(contract);
        }

        public ContractDTO updateContract(ContractDTO contract)
        {
            var update = _uow.GetRepository<Contract>().Get(z => z.Id == contract.Id);
            update = MapperFactory.CurrentMapper.Map<Contract>(contract);
            _uow.GetRepository<Contract>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ContractDTO>(update);
        }
    }
}
