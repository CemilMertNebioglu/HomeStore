using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface IRecPersonService : IServiceBase
    {
        List<RecPersonDTO> getAll();
        RecPersonDTO getRecPerson(int recpersonId);
        Task<RecPersonDTO> getRecPersonAsync(int recpersonId);

        RecPersonDTO addRecPerson(RecPersonDTO recPerson);
        RecPersonDTO updateRecPerson(RecPersonDTO recPerson);
        bool deleteRecPerson(int recpersonId);
    }
}
