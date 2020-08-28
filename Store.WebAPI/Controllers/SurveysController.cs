using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.Abstract;
using Store.DTO;

namespace Store.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyservice;
        public SurveysController(ISurveyService surveyservice)
        {
            _surveyservice = surveyservice;
        }
        [HttpGet]
        [Route("action")]

        public List<SurveyDTO> GetAll()
        {
            return _surveyservice.getAll();
        }
        [HttpGet("{id}")]
        [Route("action")]

        public Task<SurveyDTO> GetAsync(int id)
        {
            return _surveyservice.getSurveyAsync (id);
        }
        [HttpGet]
        [Route("action")]
        public SurveyDTO Get(int id)
        {
            return _surveyservice.getSurvey(id);
        }
        [HttpPost]
        [Route("action")]

        public SurveyDTO Add(SurveyDTO dto)
        {
            return _surveyservice.addSurvey(dto);
        }
        [HttpPut]
        [Route("action")]

        public SurveyDTO Update(SurveyDTO dto)
        {
            return _surveyservice.updateSurvey(dto);
        }
        [HttpDelete]
        [Route("action")]

        public bool Delete(int id)
        {
            return _surveyservice.deleteSurvey(id);
        }
    }
}