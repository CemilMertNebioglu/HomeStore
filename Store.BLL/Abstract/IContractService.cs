using Store.Core.Services;
using Store.CORE.Data.Repositories;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IContractService : IServiceBase
    {
        List<ContractDTO> getAll();
        ContractDTO getContract(int contractId);
        Task<ContractDTO> getContractAsync(int contractId);
        ContractDTO addContract(ContractDTO contract);

        ContractDTO updateContract(ContractDTO contract);
        bool deleteContract(int contractId);
    }
}
