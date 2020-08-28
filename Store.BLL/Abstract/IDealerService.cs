using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IDealerService : IServiceBase
    {
        List<DealerDTO> getAll();
        DealerDTO getDealer(int dealerId);
        Task<DealerDTO> getDealerAsync(int dealerId);
        DealerDTO addDealer(DealerDTO dealer);
        DealerDTO updateDealer(DealerDTO dealer);
        bool deleteDealer(int dealerId);


    }
}
