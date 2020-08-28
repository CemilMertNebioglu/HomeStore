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
    public class SurveyService : ISurveyService
    {
        private readonly IUnitofWork _uow;
        public SurveyService(IUnitofWork uow)
        {
            _uow = uow;
            
        }
        public SurveyDTO addSurvey(SurveyDTO survey)
        {
            if (!_uow.GetRepository<Survey>().GetAll().Any(z=> z.Name == survey.Name))
            {
                var add = MapperFactory.CurrentMapper.Map<Survey>(survey);
                _uow.GetRepository<Survey>().Add(add);
                _uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SurveyDTO>(add);
            }
            else
            {
                return null;
            }
        }

        public bool deleteSurvey(int surveyId)
        {
            try
            {
                var delete = _uow.GetRepository<Survey>().Get(z => z.Id == surveyId);
                _uow.GetRepository<Survey>().Delete(delete);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SurveyDTO> getAll()
        {
            var list = _uow.GetRepository<Survey>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<SurveyDTO>>(list);
        }

        public async Task<SurveyDTO> getSurveyAsync(int surveyId)
        {
            var survey = await _uow.GetRepository<Survey>().GetAsync(z => z.Id == surveyId);
            return MapperFactory.CurrentMapper.Map<SurveyDTO>(survey);
        }

        public SurveyDTO getSurvey(int surveyId)
        {
            var survey =_uow.GetRepository<Survey>().Get(z => z.Id == surveyId);
            return MapperFactory.CurrentMapper.Map<SurveyDTO>(survey);
        }

        public SurveyDTO updateSurvey(SurveyDTO survey)
        {
            var update = _uow.GetRepository<Survey>().Get(z => z.Id == survey.Id);
            update = MapperFactory.CurrentMapper.Map<Survey>(survey);
            _uow.GetRepository<Survey>().Update(update);
            _uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SurveyDTO>(update);
        }
    }
}
