using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IDealerClient
    {
        Task<List<DealerDTO>> GetAll();
        Task<DealerDTO> Get(int Id);
        Task<DealerDTO> AddDealer(DealerDTO dto);
        Task<DealerDTO> UpdateDealer(DealerDTO dto);
        Task<string> Delete(string Id);
    }
}
