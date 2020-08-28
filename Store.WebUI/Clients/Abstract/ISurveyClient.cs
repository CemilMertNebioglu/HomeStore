using Store.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Abstract
{
    public interface ISurveysClient
    {
        Task<List<SurveyDTO>> GetAll();
        Task<SurveyDTO> Get(int Id);
        Task<SurveyDTO> AddSurvey(SurveyDTO dto);
        Task<SurveyDTO> UpdateSurvey(SurveyDTO dto);
        Task<string> Delete(string Id);
    }
}
