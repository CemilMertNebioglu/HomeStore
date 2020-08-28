using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface IRecPersonClient
    {
        Task<List<RecPersonDTO>> GetAll();
        Task<RecPersonDTO> Get(int Id);
        Task<RecPersonDTO> AddRecPerson(RecPersonDTO dto);
        Task<RecPersonDTO> UpdateRecPerson(RecPersonDTO dto);
        Task<string> Delete(string Id);
    }
}
