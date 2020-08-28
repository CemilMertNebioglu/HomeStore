using Store.Core.Services;
using Store.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Abstract
{
   public interface ISurveyService :IServiceBase
    {
        List<SurveyDTO> getAll();
        SurveyDTO getSurvey(int surveyId);
        Task<SurveyDTO> getSurveyAsync(int surveyId);
        SurveyDTO addSurvey(SurveyDTO survey);
        SurveyDTO updateSurvey(SurveyDTO survey);
        bool deleteSurvey(int surveyId);

    }
}
