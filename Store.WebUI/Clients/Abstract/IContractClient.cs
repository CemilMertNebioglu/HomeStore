using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IContractClient
    {
        Task<List<ContractDTO>> GetAll();
        Task<ContractDTO> Get(int Id);
        Task<ContractDTO> AddContract(ContractDTO dto);
        Task<ContractDTO> UpdateContract(ContractDTO dto);
        Task<string> Delete(string Id);
    }
}
